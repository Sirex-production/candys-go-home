using UnityEngine;

namespace Candy.Settings
{
	public sealed class SettingsService : MonoBehaviour
	{
		private void Awake()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}