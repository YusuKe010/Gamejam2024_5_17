using UnityEngine;

public class PlayerPollen : MonoBehaviour, IDamageable, IPose
{
	[SerializeField, Header("初期HP")] private float _initiateHp;
	[SerializeField, Header("Hpの減る速度")] private float _damageRate;
	[SerializeField, Header("初期の大きさ")] private Vector3 _initiateScale = new Vector3(1, 1, 1) ;

	private bool _isPose = false;
	
	private float _currentHp;
	public float CurrentHp => _currentHp;

	private void Start()
	{
		_currentHp = _initiateHp;
		transform.localScale = _initiateScale;
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
    void GameOver()
    {

		SceneChanger.Instance.SceneChange("result");
    }

    public void AddDamage(float damage)
	{
		if (_currentHp > 0)
		{
			_currentHp -= damage;
			ChangeScale();
		}
		else
		{
			GameOver();
        }
	}

	public void Kill()
	{
		if (!_isPose)
		{
			_currentHp = 0;
			SaveManage.Instance.Data.InfectionCount += 1;
			SaveManage.Instance.Save(SaveManage.Instance.Data);
			GameOver();
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
