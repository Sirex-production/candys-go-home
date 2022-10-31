using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy
{
    public class EnemyManagerService: MonoBehaviour
    {
        [SerializeField] 
        [Required]
        private Transform target;
        
        public void SurroundTarget()
        {
            
        }
        
    }
}