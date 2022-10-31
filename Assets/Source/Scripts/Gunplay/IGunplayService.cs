using System;

namespace Candy.Gunplay
{
	public interface IGunplayService
	{
		public event Action<int> OnWeaponSwitched;
	}
}