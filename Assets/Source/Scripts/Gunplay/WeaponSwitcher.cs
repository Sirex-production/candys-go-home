using Candy.Player;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class WeaponSwitcher : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private Transform[] gunTransforms;
		
		private IGunplayService _gunplayService;
		
		[Inject]
		private void Construct(IGunplayService gunplayService)
		{
			_gunplayService = gunplayService;
		}

		private void Awake()
		{
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
		}

		private void OnDestroy()
		{
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
		}

		private void OnWeaponSwitched(int currentWeaponIndex)
		{
			for (int i = 0; i < gunTransforms.Length; i++)
				gunTransforms[i].gameObject.SetActive(currentWeaponIndex == i);
		}
	}
}