public interface IDamageable
{
	/// <summary>ダメージを与える</summary>
	void AddDamage(float damage, EnemyType enemyType);

	/// <summary>一撃必殺</summary>
	void Kill();
}
