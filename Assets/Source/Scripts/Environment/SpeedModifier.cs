using Candy.Player;
using UnityEngine;
using Zenject;

namespace Candy.Environment
{
	public sealed class SpeedModifier : MonoBehaviour
	{
		[SerializeField] [Min(0)] private float targetSpeed = 30f; 
		[SerializeField] [Min(0)] private float duration = 1f; 
		
		private IPlayerService _playerService;
		
		[Inject]
		private void Construct(IPlayerService playerService)
		{
			_playerService = playerService;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_playerService.RequestSpeedChange(targetSpeed, duration);
			}
		}
	}
}