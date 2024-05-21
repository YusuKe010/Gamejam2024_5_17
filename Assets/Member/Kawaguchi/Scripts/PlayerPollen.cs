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

	void ChangeScale()
	{
		transform.localScale = _initiateScale * (_currentHp / _initiateHp);
	}

	public void AddDamage(float damage)
	{
		if (_currentHp > 0)
		{
			_currentHp -= damage;
			ChangeScale();
		}
	}

	public void Kill()
	{
		if (!_isPose)
		{
			_currentHp = 0;
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
