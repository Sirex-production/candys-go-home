using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Support.Extensions;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.Universal;

namespace Candy.VFX
{
	public sealed class VfxService : MonoBehaviour, IVfxService
	{
		[BoxGroup("References")]
		[Required, SerializeField] private VfxConfig vfxConfig;

		private IObjectPool<DecalProjector> _decalsPool;
		private Dictionary<DecalProjector, float> _decalLifetimes;

		private void Awake()
		{
			_decalsPool = new ObjectPool<DecalProjector>
			(
				CreateBulletDecal,
				OnBulletDecalGet,
				OnBulletDecalRelease
			);

			_decalLifetimes = new Dictionary<DecalProjector, float>();

			this.RepeatCoroutine(1f, () => TryToRemoveDecals(1f), true);
		}

		private void TryToRemoveDecals(float pauseBetween)
		{
			foreach (var key in _decalLifetimes.Keys.ToList())
			{
				_decalLifetimes[key] -= pauseBetween;
				
				if(_decalLifetimes[key] > 0)
					continue;
				
				_decalsPool.Release(key);
				_decalLifetimes.Remove(key);
			}
		}

		public void SpawnBulletDecal(Vector3 targetPos, Vector3 lookDirection)
		{
			var decalInstance = _decalsPool.Get();
			
			decalInstance.transform.position = targetPos;
			decalInstance.transform.rotation = Quaternion.LookRotation(lookDirection);
			_decalLifetimes.Add(decalInstance, vfxConfig.BulletDecalLifetime);
		}

		private DecalProjector CreateBulletDecal()
		{
			return Instantiate(vfxConfig.BulletDecalPrefab);
		}

		private void OnBulletDecalGet(DecalProjector bulletDecal)
		{
			bulletDecal.SetGameObjectActive();
		}

		private void OnBulletDecalRelease(DecalProjector bulletDecal)
		{
			bulletDecal.SetGameObjectInactive();
		}
	}
}