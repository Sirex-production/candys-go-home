using DG.Tweening;
using NaughtyAttributes;
using Support.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Candy.GameplayUi
{
	public sealed class UiCombatDisplay : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private Image brushIcon;
		[BoxGroup("References")]
		[SerializeField] private Image[] weaponIcons;
		[BoxGroup("References")]
		[Required, SerializeField] private TMP_Text ammoText;
		[BoxGroup("Animation properties")]
		[SerializeField] [Min(0)] private float fadeAnimationDuration = .3f;
		
		private IUiGameplayService _uiGameplayService;

		[Inject]
		private void Construct(IUiGameplayService uiGameplayService)
		{
			_uiGameplayService = uiGameplayService;
		}

		private void Awake()
		{
			_uiGameplayService.OnInventoryUiWeaponsUpdateRequested += OnInventoryUiWeaponsUpdateRequested;
			_uiGameplayService.OnWeaponSwitchUiUpdateRequested += OnWeaponSwitchUiUpdateRequested;
			_uiGameplayService.OnCurrentAmountOfAmmoUiUpdateRequested += OnCurrentAmountOfAmmoUiUpdateRequested;
		}

		private void OnDestroy()
		{
			_uiGameplayService.OnInventoryUiWeaponsUpdateRequested -= OnInventoryUiWeaponsUpdateRequested;
			_uiGameplayService.OnWeaponSwitchUiUpdateRequested -= OnWeaponSwitchUiUpdateRequested;
			_uiGameplayService.OnCurrentAmountOfAmmoUiUpdateRequested -= OnCurrentAmountOfAmmoUiUpdateRequested;
		}

		private void OnWeaponSwitchUiUpdateRequested(int weaponIndex)
		{
			if (weaponIndex < 0)
			{
				brushIcon.DOFade(1, fadeAnimationDuration);
				return;
			}

			brushIcon.DOFade(.3f, fadeAnimationDuration);


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
			brushIcon.SetGameObjectActive();
			
			for (int i = 0; i < weaponsInInventory.Length; i++)
				weaponIcons[i].gameObject.SetActive(weaponsInInventory[i]);
		}

		private void OnCurrentAmountOfAmmoUiUpdateRequested(int amountOfAmmo)
		{
			string targetText = amountOfAmmo < 0 ? "INFINITE" : $"{amountOfAmmo}";;

			ammoText.SetText($"AMMO: {targetText}");
		}
	}
}