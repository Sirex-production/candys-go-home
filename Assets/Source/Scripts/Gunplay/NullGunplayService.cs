using System;

namespace Candy.Player
{
	public sealed class NullGunplayService : IGunplayService
	{
		public event Action<int> OnWeaponSwitched;
	}
}