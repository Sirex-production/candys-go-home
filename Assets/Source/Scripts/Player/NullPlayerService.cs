using System;

namespace Candy.Player
{
	public sealed class NullPlayerService : IPlayerService
	{
		public event Action<float> OnCustomJumpRequested;
		public event Action<float> OnSpeedChangeRequested;
		public event Action<float> OnHealthUpdated;

		public void RequestCustomJump(float jumpForce)
		{
			
		}

		public void RequestSpeedChange(float speed, float duration)
		{
			
		}

		public void TakeDamage(float damage)
		{
			
		}

		public void Heal(float health)
		{
			
		}
	}
}