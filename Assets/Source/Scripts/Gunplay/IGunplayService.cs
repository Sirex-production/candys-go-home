using System;

namespace Candy.Gunplay
{
	public interface IGunplayService
	{
		public event Action<int> OnWeaponSwitched;
		public event Action OnMeleeWeaponSwitched;
		public event Action<int> OnAttackPerformed;

		public int CurrentWeaponIndex { get; }
		public bool IsAbleToAttack { get; set; }
	}
}