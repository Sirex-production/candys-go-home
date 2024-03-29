﻿using Candy.Actors;
using Candy.Player;
using Candy.VFX;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Projectile
{
	[RequireComponent(typeof(Rigidbody))]
	public sealed class ProjectileInteraction : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private ProjectileSubject projectileSubject;

		private IVfxService _vfxService;
		private IPlayerService _playerService;
		
		private bool _isReleasedByPlayer;

		[Inject]
		private void Construct(IVfxService vfxService, IPlayerService playerService)
		{
			_vfxService = vfxService;
			_playerService = playerService;
		}

		private void Awake()
		{
			projectileSubject.OnLaunch += OnLaunch;
			projectileSubject.OnInitialStateReset += OnInitialStateReset;
		}

		private void OnDestroy()
		{
			projectileSubject.OnLaunch -= OnLaunch;
			projectileSubject.OnInitialStateReset -= OnInitialStateReset;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.isTrigger && !other.CompareTag("Player") && !other.CompareTag("Enemy"))
			{
				var forwardDirection = transform.forward; 
				
				projectileSubject.InteractWithSurface();
				_vfxService.SpawnBulletDecal(transform.position - forwardDirection, forwardDirection);
				
				return;
			}

			if (other.CompareTag("Player") && !_isReleasedByPlayer)
			{
				_playerService.TakeDamage(projectileSubject.Damage);
				projectileSubject.InteractWithSurface();
				return;
			}

			if (other.CompareTag("Enemy") && _isReleasedByPlayer)
			{
				if (other.transform.root.TryGetComponent<ActorHealth>(out var health))
				{
					health.TakeDamage(projectileSubject.Damage);
				}
				projectileSubject.InteractWithSurface();
			}
		}

		private void OnLaunch(Vector3 _, Vector3 __, bool isReleasedByPlayer)
		{
			_isReleasedByPlayer = isReleasedByPlayer;
		}

		private void OnInitialStateReset()
		{
			_isReleasedByPlayer = false;
		}
	}
}