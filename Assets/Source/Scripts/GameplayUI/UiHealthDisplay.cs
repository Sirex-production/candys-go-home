using NaughtyAttributes;
using Support.UI;
using UnityEngine;
using Zenject;

namespace Candy.GameplayUi
{
	public sealed class UiHealthDisplay : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private UiSlider healthSlider;
		[BoxGroup("Animation properties")]
		[SerializeField] [Min(0)] private float lerpingSpeed = 10f;
		
		private IUiGameplayService _uiGameplayService;
		
		[Inject]
		private void Construct(IUiGameplayService uiGameplayService)
		{
			_uiGameplayService = uiGameplayService;
		}

		private void Awake()
		{
			_uiGameplayService.OnHealthUiUpdateRequested += OnHealthUiUpdateRequested;
		}

		private void OnDestroy()
		{
			_uiGameplayService.OnHealthUiUpdateRequested -= OnHealthUiUpdateRequested;
		}

		private void OnHealthUiUpdateRequested(float healthInPercentage)
		{
			healthSlider.SetFrontImageWithLerping(lerpingSpeed, healthInPercentage);
			healthSlider.SetBackImageWithLerping(lerpingSpeed / 2, healthInPercentage);
		}
	}
}