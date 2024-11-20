
using Mobile_Farming_Game.Scripts.Data;
using Mobile_Farming_Game.Scripts.Player;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("----- ELEMENTS ------")]
    [SerializeField] private MobileJoystick mobileJoystick;
    [SerializeField] private PlayerData playerData;
    private PlayerAnimator _playerAnimator;
    private CharacterController _characterController;
        
    [Header("----- SETTINGS ------")]
    private float _currentMoveSpeed;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _currentMoveSpeed = playerData.moveSpeed;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var moveVector = mobileJoystick.GetMoveVector() * (_currentMoveSpeed * Time.deltaTime) / Screen.width;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        
        _characterController.Move(moveVector);
        _playerAnimator.ManageAnimations(moveVector);
    }
}
