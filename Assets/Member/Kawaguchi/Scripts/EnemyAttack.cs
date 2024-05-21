using UnityEngine;

public enum EnemyType
{
	Human,
	Bee,
}

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] private EnemyType _enemyType;
	[SerializeField, Header("攻撃力")] private float _atk = 1;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<IDamageable>() != null)
		{
			other.GetComponent<IDamageable>().AddDamage(_atk, _enemyType);
		}
	}
}
