using Candy.Player;
using UnityEngine;
using Zenject;

namespace Candy.Environment
{
	[RequireComponent(typeof(Collider))]
	public sealed class Trampoline : MonoBehaviour
	{
		[SerializeField] [Min(0)] private float jumpForce = 30f; 
		
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
				_playerService.RequestCustomJump(jumpForce);
			}
		}
	}
}