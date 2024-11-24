using System;
using Mobile_Farming_Game.Scripts.Tiles;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerSowAbility : MonoBehaviour
    {
        [Header("----- ELEMENTS ------")]
        private PlayerAnimator _playerAnimator;
        
        [Header("----- SETTINGS ------")]
        private CropField _currentCropField;

        private void Start()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
            SeedParticles.OnParticleCollisionAction += SeedsCollidedCallback;
        }

        private void OnDestroy()
        {
            SeedParticles.OnParticleCollisionAction -= SeedsCollidedCallback;
        }

        private void Update()
        {
            
        }

        private void SeedsCollidedCallback(Vector3[] seedsPositions)
        {
            if (_currentCropField == null) return;
            _currentCropField.SeedsCollidedCallback(seedsPositions);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
                _currentCropField = other.GetComponent<CropField>();
                _playerAnimator.PlaySowAnimation();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
               _currentCropField = null;
                _playerAnimator.StopSowAnimation();
            }
        }
    }
}