using System;

namespace Candy.CameraWork
{
	public interface ICameraWorkService
	{
		public event Action<float> OnRecoilAdded;
		public event Action OnLandEffectRequested;

		public void AddRecoil(float recoilStrength);
		public void RequestLandEffect();
	}
}