using UnityEngine;

namespace Candy.VFX
{
	public interface IVfxService
	{
		public void SpawnBulletDecal(Vector3 targetPos, Vector3 lookDirection);
	}
}