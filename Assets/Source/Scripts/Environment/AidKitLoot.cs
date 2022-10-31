using Candy.Player;
using UnityEngine;
using Zenject;

namespace Candy.Environment
{
	[RequireComponent(typeof(Collider))]
	public sealed class AidKitLoot : MonoBehaviour
	{
		[SerializeField] [Range(0, 100f)] private float healAmount = 25f;

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
				_playerService.Heal(healAmount);
				Destroy(gameObject);
			}
		}
	}
}