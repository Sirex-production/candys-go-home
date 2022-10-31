using UnityEngine;

namespace Candy.VFX
{
	public sealed class NullVfxService : IVfxService
	{
		public void SpawnBulletDecal(Vector3 targetPos, Vector3 lookDirection)
		{
			throw new System.NotImplementedException();
		}
	}
}