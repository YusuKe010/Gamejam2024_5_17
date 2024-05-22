using System.Collections;
using System.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerPollen : MonoBehaviour, IDamageable, IPose
{
    [SerializeField, Header("初期HP")] private float _initiateHp;
    [SerializeField, Header("Hpの減る速度")] private float _damageRate;
    [SerializeField, Header("初期の大きさ")] private Vector3 _initiateScale = new Vector3(1, 1, 1);
    [SerializeField, Header("蜂で死んだときのパネル")] private GameObject _hatipane;
    [SerializeField, Header("人間")] GameObject _humanpanel;
    [SerializeField, Header("雨のパネル")] GameObject _rainpanel;
    [SerializeField] ParticleSystem _particle;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] AudioClip _sounds;
    Rigidbody2D _rigidbody2;
    AudioSource _sound;

    private bool _isPose = false;
    bool _isdie = false;

    private float _currentHp;
    public float CurrentHp => _currentHp;

    private void Start()
    {
        _isdie = false;
        _currentHp = _initiateHp;
        transform.localScale = _initiateScale;

        _rainpanel.SetActive(false);
        _humanpanel.SetActive(false);
        _hatipane.SetActive(false);
        _rigidbody2 = GetComponent<Rigidbody2D>();
        _sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // if (!_isPose)
        // {
        // 	ContinuouslyDecrease();
        // }
    }

    ///<summary>徐々にHpが減る</summary>
    void ContinuouslyDecrease()
    {
        if (_currentHp > 0)
        {
            _currentHp -= _damageRate * Time.deltaTime;
            ChangeScale();
        }
    }

    /// <summary>
    /// 大きさを変える
    /// </summary>
    void ChangeScale()
    {
        transform.localScale = _initiateScale * (_currentHp / _initiateHp);
    }


    /// <summary>
    /// ゲームオーバー時
    /// </summary>

    IEnumerator GameOver()
    {
        _rigidbody2.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
        foreach (var item in FindObjectsOfType<GameObject>()
                     .Where(_ => _.GetComponent<IPose>() != null)
                     .Select(_ => _.GetComponent<IPose>()).ToList())
        {
            item.OutPose();
        }
        SceneChanger.Instance.SceneChange("result");
    }

    public void AddDamage(float damage, EnemyType e)
    {
        if (_currentHp > 0)
        {
            _currentHp -= damage;
            ChangeScale();

            if(e == EnemyType.Human)
            {
                _sound.clip = _audioClip;
                _sound.Play();
            }
            else
            {
                _particle.Play();
                _sound.clip = _sounds;
                _sound.Play();
            }
        }
        else if(!_isdie)
        {
            switch (e)
            {
                case EnemyType.Human:
                    _humanpanel.SetActive(true);
                    break;
                case EnemyType.Bee:
                    _hatipane.SetActive(true);
                    break;
                case EnemyType.Cloud:
                    _rainpanel.SetActive(true); 
                    break;
            }
            foreach (var item in FindObjectsOfType<GameObject>()
                     .Where(_ => _.GetComponent<IPose>() != null)
                     .Select(_ => _.GetComponent<IPose>()).ToList())
            {
                item.InPose();
            }
            _isdie = true;
            StartCoroutine(GameOver());
        }
    }

    public void Kill()
    {
        if (!_isPose)
        {
            foreach (var item in FindObjectsOfType<GameObject>()
                     .Where(_ => _.GetComponent<IPose>() != null)
                     .Select(_ => _.GetComponent<IPose>()).ToList())
            {
                item.InPose();
            }
            _currentHp = 0;
            _rainpanel.SetActive(true);
            StartCoroutine(GameOver());
        }
    }


    public void InPose()
    {
        _isPose = true;
        Debug.Log("InPose");
    }

    public void OutPose()
    {
        _isPose = false;
        Debug.Log("OutPose");
    }
}
