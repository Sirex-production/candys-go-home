using System;

namespace Candy.Player
{
	public interface IGunplayService
	{
		public event Action<int> OnWeaponSwitched;
	}
}