using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Player
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        [Header("----- ELEMENTS ------")]
        [SerializeField] private ParticleSystem seedParticles;
        
        
        private void PlaySeedParticles()
        {
            seedParticles.Play();
        }
        
    }
}