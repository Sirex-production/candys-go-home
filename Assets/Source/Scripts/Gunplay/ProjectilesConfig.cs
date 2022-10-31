﻿using UnityEngine;

namespace Candy.Gunplay
{
	[CreateAssetMenu(menuName = "Gunplay/Projectile config")]
	public sealed class ProjectilesConfig : ScriptableObject
	{
		[SerializeField] private ProjectileSubject[] projectilesPrefabs;

		public int AmountOfProjectileTypes => projectilesPrefabs.Length;
		
		public ProjectileSubject GetProjectile(int projectileId)
		{
			return projectilesPrefabs[projectileId];
		}
	}
}