using Candy.Actors;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Environment 
{
	public sealed class BreakableObject : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private ActorHealth attachedHealth;

		private void Awake()
		{
			attachedHealth.OnDie += OnDie;
		}

		private void OnDestroy()
		{
			attachedHealth.OnDie -= OnDie;
		}

		private void OnDie()
		{
			Destroy(gameObject);
		}
	}
}