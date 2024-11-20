using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {

        [Header("----- ELEMENTS ------")]
        [SerializeField] private Animator animator;
        
        [Header("----- SETTINGS ------")]
        [SerializeField] private float moveSpeedMultiplier;
        
        public void ManageAnimations(Vector3 moveVector)
        {
            if (moveVector.magnitude > 0)
            {
                animator.SetFloat("moveSpeed", moveVector.magnitude * moveSpeedMultiplier);
                PlayRunAnimation();
                
                animator.transform.forward = moveVector.normalized;
            }
            else
                PlayIdleAnimation();
        }

        private void PlayIdleAnimation()
        {
            animator.Play("Idle");
        }

        private void PlayRunAnimation()
        {
            animator.Play("Run");
        }
    }
}