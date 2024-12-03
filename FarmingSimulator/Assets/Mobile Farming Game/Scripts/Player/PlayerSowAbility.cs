using System;
using Mobile_Farming_Game.Scripts.Tiles;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerToolSelector))]
    public class PlayerSowAbility : MonoBehaviour
    {
        [Header("----- ELEMENTS ------")]
        private PlayerAnimator _playerAnimator;
        private PlayerToolSelector _playerToolSelector;
        
        [Header("----- SETTINGS ------")]
        private CropField _currentCropField;

        private void Awake()
        {
            _playerToolSelector = GetComponent<PlayerToolSelector>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Start()
        {
            SeedParticles.OnParticleCollisionAction += SeedsCollidedCallback;
            CropField.OnFieldFullySown += OnFieldFullySownCallback;
            PlayerToolSelector.OnToolChanged += OnToolChangedCallback;
        }

        private void OnDestroy()
        {
            SeedParticles.OnParticleCollisionAction -= SeedsCollidedCallback;
            CropField.OnFieldFullySown -= OnFieldFullySownCallback;
            PlayerToolSelector.OnToolChanged -= OnToolChangedCallback;
        }

        private void OnToolChangedCallback(PlayerToolSelector.Tool changedTool)
        {
            if(!_playerToolSelector.CanSow())
                _playerAnimator.StopSowAnimation();
        }

        private void SeedsCollidedCallback(Vector3[] seedsPositions)
        {
            if (_currentCropField == null) return;
            _currentCropField.SeedsCollidedCallback(seedsPositions);
        }

        private void OnFieldFullySownCallback(CropField obj)
        {
            if (obj == _currentCropField)
                _playerAnimator.StopSowAnimation();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
            {
                _currentCropField = other.GetComponent<CropField>();
                EnteredCropField(_currentCropField);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("CropField"))
                EnteredCropField(other.GetComponent<CropField>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
               _currentCropField = null;
                _playerAnimator.StopSowAnimation();
            }
        }

        private void EnteredCropField(CropField cropField)
        {
            if (_playerToolSelector.CanSow())
                _playerAnimator.PlaySowAnimation();
        }
    }
}