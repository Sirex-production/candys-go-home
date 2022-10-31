using System;
using UnityEngine;

namespace Candy.CameraWork
{
	public sealed class CameraWorkService : MonoBehaviour, ICameraWorkService
	{
		public event Action<float> OnRecoilAdded;
		public event Action OnLandEffectRequested;

		public void AddRecoil(float recoilStrength)
		{
			OnRecoilAdded?.Invoke(recoilStrength);
		}

		public void RequestLandEffect()
		{
			OnLandEffectRequested?.Invoke();
		}
	}
}