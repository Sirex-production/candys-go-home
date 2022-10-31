using System;
using Support;
using UnityEngine;
using Zenject;

namespace Candy.LoadingUi
{
	public sealed class UiLoadingService : MonoBehaviour, IUiLoadingService
	{
		private LevelManagementService _levelManagementService;

		public event Action OnLoadingUiShowRequested;
		public event Action OnLoadingUiHideRequested;
		public event Action<float> OnLoadingProgressUiUpdated;
		
		[Inject]
		private void Construct(LevelManagementService levelManagementService)
		{
			_levelManagementService = levelManagementService;
		}

		private void Awake()
		{
			_levelManagementService.OnLoadingStarted += OnLoadingStarted;
			_levelManagementService.OnLoadingFinished += OnLoadingFinished;
			_levelManagementService.OnLoadingProgressUpdated += OnLoadingProgressUpdated;
		}
		
		private void OnDestroy()
		{
			_levelManagementService.OnLoadingStarted -= OnLoadingStarted;
			_levelManagementService.OnLoadingFinished -= OnLoadingFinished;
			_levelManagementService.OnLoadingProgressUpdated -= OnLoadingProgressUpdated;
		}

		private void OnLoadingStarted()
		{
			OnLoadingUiShowRequested?.Invoke();
		}
		
		private void OnLoadingFinished()
		{
			OnLoadingUiHideRequested?.Invoke();
		}

		private void OnLoadingProgressUpdated(float progress)
		{
			const float additionalProgressOffset = .15f;
			OnLoadingProgressUiUpdated?.Invoke(progress + additionalProgressOffset);
		}
	}
}