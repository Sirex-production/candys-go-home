using NaughtyAttributes;
using UnityEngine;

namespace Candy.Player
{
	[CreateAssetMenu(menuName = "Player/PlayerConfig")]
	public sealed class PlayerConfig : ScriptableObject
	{
		[BoxGroup("Movement")]
		[SerializeField] [Min(0)] private float movementSpeed;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0)] private float rotationSpeed;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0)] private float accelerationSpeed;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0)] private float mass;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0)] private float jumpForce;
		
		public float MovementSpeed => movementSpeed;
		public float RotationSpeed => rotationSpeed;
		public float AccelerationSpeed => accelerationSpeed;
		public float Mass => mass;
		public float JumpForce => jumpForce;
	}
}