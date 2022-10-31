using System;

namespace Candy.GameplayUi
{
	public sealed class NullUiGameplayService : IUiGameplayService
	{
		public event Action<int> OoWeaponSwitchUiUpdateRequested;
		public event Action<bool[]> OnInventoryUiWeaponsUpdateRequested;
		public event Action<float> OnHealthUiUpdateRequested;
	}
}