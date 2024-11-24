using System;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerSowAbility : MonoBehaviour
    {
        [Header("----- ELEMENTS ------")]
        private PlayerAnimator _playerAnimator;

        private void Start()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CropField"))
                _playerAnimator.PlaySowAnimation();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("CropField"))
                _playerAnimator.StopSowAnimation();
        }
    }
}