using System;

namespace Candy.GameplayUi
{
	public sealed class NullUiGameplayService : IUiGameplayService
	{
		public event Action<int> OnWeaponSwitchUiUpdateRequested;
		public event Action<bool[]> OnInventoryUiWeaponsUpdateRequested;
		public event Action<float> OnHealthUiUpdateRequested;
		public event Action<int> OnCurrentAmountOfAmmoUiUpdateRequested;
		public event Action OnEscPopupActivenessChange;
		
		public void ChangeEcsMenuActivity()
		{
			
		}
	}
}