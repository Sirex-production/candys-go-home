using NaughtyAttributes;
using Support;
using Support.Extensions;
using TMPro;
using UnityEngine;

namespace Candy.Common
{
	public sealed class NarrativeTextPresenter : MonoSingleton<NarrativeTextPresenter>
	{
		[Required, SerializeField] private TMP_Text narrativeText;

		public void PlayerPhrase0()
		{
			narrativeText.SpawnTextCoroutine("Helloween. Spooky days...", .01f);
		}
		
		public void PlayerPhrase1()
		{
			narrativeText.SpawnTextCoroutine("Days when a lot of people got a lot of sweets...", .01f);
		}
		
		public void PlayerPhrase2()
		{
			narrativeText.SpawnTextCoroutine("But not every candy get to the humans' home! Some of them are thrown to the trash just because they are expired...", .01f);
		}
		
		public void PlayerPhrase3()
		{
			narrativeText.SpawnTextCoroutine("Time to eliminate new sweets and get to the humans' home...", .05f);
		}
	}
}