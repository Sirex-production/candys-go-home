using Candy.Gunplay;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Candy.GameplayUi
{
	public sealed class UiCombatDisplay : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private Image[] weaponIcons;
		[BoxGroup("Animation properties")]
		[SerializeField] [Min(0)] private float fadeAnimationDuration = .3f;
		
		private IUiGameplayService _uiGameplayService;
		private IGunplayService _gunplayService;
		
		[Inject]
		private void Construct(IUiGameplayService uiGameplayService, IGunplayService gunplayService)
		{
			_uiGameplayService = uiGameplayService;
			_gunplayService = gunplayService;
		}

		private void Awake()
		{
			_uiGameplayService.OnInventoryUiWeaponsUpdateRequested += OnInventoryUiWeaponsUpdateRequested;
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
			_gunplayService.OnMeleeWeaponSwitched += OnMeleeWeaponSwitched;
		}

		private void OnDestroy()
		{
			_uiGameplayService.OnInventoryUiWeaponsUpdateRequested -= OnInventoryUiWeaponsUpdateRequested;
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
			_gunplayService.OnMeleeWeaponSwitched -= OnMeleeWeaponSwitched;
		}

		private void OnMeleeWeaponSwitched()
		{
			OnWeaponSwitched(-1);
		}

		private void OnWeaponSwitched(int weaponIndex)
		{
			weaponIndex += 1;
			
			for (int i = 0; i < weaponIcons.Length; i++)
			{
				var weaponIcon = weaponIcons[i];
				
				if(!weaponIcon.isActiveAndEnabled)
					continue;

				if (i == weaponIndex)
					weaponIcon.DOFade(1, fadeAnimationDuration);
				else
					weaponIcon.DOFade(.3f, fadeAnimationDuration);
			}
		}

		private void OnInventoryUiWeaponsUpdateRequested(bool[] weaponsInInventory)
		{
			for (int i = 0; i < weaponsInInventory.Length; i++)
				weaponIcons[i].gameObject.SetActive(weaponsInInventory[i]);
		}
	}
}