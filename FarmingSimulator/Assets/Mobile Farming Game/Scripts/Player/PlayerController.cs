using System;
using System.Collections;
using System.Collections.Generic;
using Mobile_Farming_Game.Scripts.Data;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("----- ELEMENTS ------")]
    [SerializeField] private MobileJoystick mobileJoystick;
    private CharacterController _characterController;
        
    [Header("----- SETTINGS ------")]
    [SerializeField] private PlayerData playerData;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (mobileJoystick.GetMoveVector() == Vector3.zero) return;
        MovePlayer();
    }

    private void MovePlayer()
    {
        var moveVector = mobileJoystick.GetMoveVector() * (playerData.moveSpeed * Time.deltaTime) / Screen.width;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        
        _characterController.Move(moveVector);
    }
    
    
}
