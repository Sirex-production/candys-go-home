using System;
using UnityEngine;

namespace Candy.Actors
{
    public sealed class ActorHealth : MonoBehaviour
    {
        private const float HEALTH_THRESHOLD = 0;
        
        [SerializeField] 
        [Min(0)] private float health;
        public event Action OnDie;
        public event Action OnTakeDamage;
        public float Health => health;

        public void InitHealth(float initHealth)
        {
            health = initHealth;
        }

        public void TakeDamage(float dmg)
        {
            health -= dmg;
            OnTakeDamage?.Invoke();
            if (health <= HEALTH_THRESHOLD )
            {
                OnDie?.Invoke();
            }    
        }

        public void Heal(float f)
        {
            health += f;
        }
    }
}