using UnityEngine;

public enum EnemyType
{
	Human,
	Bee,
	Cloud
}

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] private EnemyType _enemyType;
	[SerializeField, Header("攻撃力")] private float _atk = 1;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<IDamageable>() != null)
		{
			if (_enemyType == EnemyType.Human)
			{
				other.GetComponent<IDamageable>().Kill();
			}
			else
			{
				other.GetComponent<IDamageable>().AddDamage(_atk);
			}
		}
	}
}
