using System;
using NaughtyAttributes;
using Support.Extensions;
using UnityEngine;

namespace Candy.Player
{
	public sealed class PlayerService : MonoBehaviour, IPlayerService
	{
		[BoxGroup("Config")]
		[Required, SerializeField] private PlayerConfig playerConfig;

		private float _currentHp;
		
		public event Action<float> OnCustomJumpRequested;
		public event Action<float> OnSpeedChangeRequested;
		public event Action<float> OnHealthUpdated;

		private void Awake()
		{
			_currentHp = playerConfig.MaxHp;
		}

		private void Start()
		{
			OnHealthUpdated?.Invoke(Mathf.InverseLerp(0, playerConfig.MaxHp, _currentHp));
		}

		public void RequestCustomJump(float jumpForce)
		{
			OnCustomJumpRequested?.Invoke(jumpForce);
		}

		public void RequestSpeedChange(float speed, float duration)
		{
			OnSpeedChangeRequested?.Invoke(speed);

			StopAllCoroutines();
			this.WaitAndDoCoroutine(duration, () => OnSpeedChangeRequested?.Invoke(playerConfig.MovementSpeed));
		}

		public void TakeDamage(float damage)
		{
			damage = Mathf.Max(0, damage);
			_currentHp -= damage;
			
			OnHealthUpdated?.Invoke(Mathf.InverseLerp(0, playerConfig.MaxHp, _currentHp));
		}

		public void Heal(float health)
		{
			health = Mathf.Max(0, health);
			_currentHp += health;
			_currentHp = Mathf.Max(_currentHp, playerConfig.MaxHp);
			
			OnHealthUpdated?.Invoke(Mathf.InverseLerp(0, playerConfig.MaxHp, _currentHp));
		}
	}
}