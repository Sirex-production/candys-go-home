using System;
using DG.Tweening;
using NaughtyAttributes;
using Support.Extensions;
using Support.UI;
using UnityEngine;
using Zenject;

namespace Candy.LoadingUi
{
	public sealed class UiLoadingScreen : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private UiSlider progressSlider;
		[BoxGroup("Animation properties")]
		[SerializeField] [Min(0)] private float animationDuration = .5f;
		
		private IUiLoadingService _loadingService;
		
		[Inject]
		private void Construct(IUiLoadingService loadingService)
		{
			_loadingService = loadingService;
		}

		private void Awake()
		{
			_loadingService.OnLoadingUiShowRequested += OnLoadingUiShowRequested;
			_loadingService.OnLoadingUiHideRequested += OnLoadingUiHideRequested;
			_loadingService.OnLoadingProgressUiUpdated += OnLoadingProgressUiUpdated;
		}

		private void OnDestroy()
		{
			_loadingService.OnLoadingUiShowRequested -= OnLoadingUiShowRequested;
			_loadingService.OnLoadingUiHideRequested -= OnLoadingUiHideRequested;
			_loadingService.OnLoadingProgressUiUpdated -= OnLoadingProgressUiUpdated;
		}

		private void OnLoadingUiShowRequested()
		{
			progressSlider.SetFrontImageFillAmount(0f);
			
			parentCanvasGroup.SetGameObjectActive();
			parentCanvasGroup.alpha = 0f;
			parentCanvasGroup.DOFade(1, animationDuration);
		}
		
		private void OnLoadingProgressUiUpdated(float progress)
		{
			progressSlider.SetFrontImageFillAmount(progress);
		}
		
		private void OnLoadingUiHideRequested()
		{
			parentCanvasGroup.SetGameObjectActive();
			parentCanvasGroup.DOFade(0, animationDuration)
							 .OnComplete(() => parentCanvasGroup.SetGameObjectInactive());
		}
	}
}