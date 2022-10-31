using System;

namespace Candy.LoadingUi
{
	public interface IUiLoadingService
	{
		public event Action OnLoadingUiShowRequested;
		public event Action OnLoadingUiHideRequested;
		public event Action<float> OnLoadingProgressUiUpdated;
	}
}