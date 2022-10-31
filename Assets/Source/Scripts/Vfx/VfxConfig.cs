using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Candy.VFX
{
	[CreateAssetMenu(menuName = "VFX/VfxConfig")]
	public sealed class VfxConfig : ScriptableObject
	{
		[SerializeField] private DecalProjector bulletDecalPrefab;
		[SerializeField] [Min(0)] private float bulletDecalLifetime;

		public DecalProjector BulletDecalPrefab => bulletDecalPrefab;
		public float BulletDecalLifetime => bulletDecalLifetime;
	}
}