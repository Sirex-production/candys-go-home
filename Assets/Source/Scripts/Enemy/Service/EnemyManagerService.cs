using Candy.Player;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy
{
    public class EnemyManagerService: MonoBehaviour, IPlayerService
    {
        [SerializeField] 
        [Required]
        private Transform target;
        
        public void SurroundTarget()
        {
            
        }
        
    }
}