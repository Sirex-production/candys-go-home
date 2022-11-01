using Support.Audio;
using UnityEngine;
using Zenject;

namespace Candy.SFX
{
	public sealed class MusicStarter : MonoBehaviour
	{
		private AudioService _audioService;
		
		[Inject]
		private void Construct(AudioService audioService)
		{
			_audioService = audioService;
		}

		private void Start()
		{
			_audioService.PlayAudio("music");
		}

		private void OnDestroy()
		{
			_audioService.StopAll();
		}
	}
}