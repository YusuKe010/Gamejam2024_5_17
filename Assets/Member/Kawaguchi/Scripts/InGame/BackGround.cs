using UnityEngine;
public class BackGround : MonoBehaviour, IPose
{
    [SerializeField]
    float scrollSpeed = -1;
    [SerializeField] float _speedUpLate;
    [SerializeField, Header("ゴール")] GameObject _goalObj;
    [SerializeField, Header("ゴールまでの距離")] float _goalDistance = 10;
    Vector3 cameraRectMin;

    bool _isPose;

    float _distance = 0;

    void Start()
    {
        //カメラの範囲を取得
        cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (!_isPose)
        {
            Move();

            if (_goalDistance >= _distance && _goalObj != null)
            {
                Instantiate(_goalObj, transform.position, transform.rotation);
            }
            else
            {
                _distance += scrollSpeed * Time.deltaTime * (1 + _speedUpLate * LevelManager.Instance.Level);
            }
        }
    }
    void Move()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime * (1 + _speedUpLate * LevelManager.Instance.Level));   //X軸方向にスクロール
        //カメラの下端から完全に出たら、上端に瞬間移動
        if (transform.position.y < (cameraRectMin.y - Camera.main.transform.position.y) * 2)
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y - cameraRectMin.y) * 2);
        }

    }

    public void InPose()
    {
        _isPose = true;
    }

    public void OutPose()
    {
        _isPose = false;
    }
}