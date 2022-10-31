using DG.Tweening;
using NaughtyAttributes;
using Support;
using Support.Extensions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Candy.GameplayUi
{
	public sealed class UiEscMenu : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private Button restartButton;
		[BoxGroup("References")]
		[Required, SerializeField] private Button continueButton;
		[BoxGroup("Animation properties")]
		[ SerializeField] private float animationDuration;

		private IUiGameplayService _uiGameplayService;
		private LevelManagementService _levelManagementService;
		
		private bool _isActive = false;

		[Inject]
		private void Construct(IUiGameplayService uiGameplayService, LevelManagementService levelManagementService)
		{
			_uiGameplayService = uiGameplayService;
			_levelManagementService = levelManagementService;
		}

		private void Awake()
		{
			_uiGameplayService.OnEscPopupActivenessChange += OnEscPopupActivenessChange;
		
			continueButton.onClick.AddListener(OnContinueButtonClicked);
			restartButton.onClick.AddListener(OnRestartButtonClicked);
			
			parentCanvasGroup.alpha = 0;
			parentCanvasGroup.SetGameObjectInactive();
		}

		private void OnDestroy()
		{
			_uiGameplayService.OnEscPopupActivenessChange -= OnEscPopupActivenessChange;
			
			continueButton.onClick.RemoveListener(OnContinueButtonClicked);
			restartButton.onClick.RemoveListener(OnRestartButtonClicked);
		}

		private void OnEscPopupActivenessChange()
		{
			_isActive = !_isActive;
			
			parentCanvasGroup.SetGameObjectActive();
			
			if (_isActive)
			{
				parentCanvasGroup.DOFade(1, animationDuration);
				
				return;
			}

			parentCanvasGroup.DOFade(0f, animationDuration)
				.OnComplete(parentCanvasGroup.SetGameObjectInactive);
		}

		private void OnContinueButtonClicked()
		{
			_uiGameplayService.ChangeEcsMenuActivity();
		}

		private void OnRestartButtonClicked()
		{
			_levelManagementService.RestartLevel();
		}
	}
}