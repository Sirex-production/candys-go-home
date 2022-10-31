using System;

namespace Candy.CameraWork
{
	public class NullCameraService : ICameraWorkService
	{
		public event Action<float> OnRecoilAdded;
		public event Action OnLandEffectRequested;
		
		public void AddRecoil(float recoilStrength)
		{
			
		}

		public void RequestLandEffect()
		{
			
		}
	}
}