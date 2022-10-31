using UnityEngine;

namespace Candy.Projectile
{
	public interface IProjectileService
	{
		public void SpawnProjectile(int projectileId, Vector3 launchPosition, Vector3 rotation, bool isReleasedByPlayer);
		public void ResetProjectile(int projectileId, ProjectileSubject projectileSubject);
	}
}