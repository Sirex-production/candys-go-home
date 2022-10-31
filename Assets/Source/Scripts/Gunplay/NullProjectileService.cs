using UnityEngine;

namespace Candy.Gunplay
{
	public sealed class NullProjectileService : IProjectileService
	{
		public void SpawnProjectile(int projectileId, Vector3 launchPosition, Vector3 rotation, bool isReleasedByPlayer)
		{
			
		}

		public void ResetProjectile(int projectileId, ProjectileSubject projectileSubject)
		{
			
		}
	}
}