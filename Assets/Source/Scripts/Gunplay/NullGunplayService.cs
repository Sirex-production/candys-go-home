using System;

namespace Candy.Gunplay
{
	public sealed class NullGunplayService : IGunplayService
	{
		public event Action<int> OnWeaponSwitched;
	}
}