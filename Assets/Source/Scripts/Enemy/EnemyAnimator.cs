using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy
{
    public sealed class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] 
        [Required]
        private Animator animator;

        [SerializeField] private string idleAnimationName;
        [SerializeField] private string walkAnimationName;
        [SerializeField] private string dieAnimationName;
        [SerializeField] private string attackAnimationName;
        
        private void PlayAnimation(string name)
        {
            animator.Play(name);
        }

        public void PlayIdle()
        {
            PlayAnimation(idleAnimationName);
        }
        
        public void PlayWalk()
        {
            PlayAnimation(walkAnimationName);
        }
        
        public void PlayAttack()
        {
            PlayAnimation(attackAnimationName);
        }
        
        public void PlayDie()
        {
            PlayAnimation(dieAnimationName);
        }
    }
}