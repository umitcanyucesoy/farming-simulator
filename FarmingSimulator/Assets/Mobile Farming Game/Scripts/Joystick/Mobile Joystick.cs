using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header("----- ELEMENTS ------")] 
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickKnob;

    [Header("----- SETTINGS ------")] 
    [SerializeField] private float moveFactor;
    private Vector3 _clickedPosition;
    private Vector3 _move;
    private bool _canControl;

    private void Start()
    {
        HideJoystick();
    }

    private void Update()
    {
        if (!_canControl) return;
        ControlJoystick();
    }

    public void ClickedOnJoystickZoneCallback()
    {
        _clickedPosition = Input.mousePosition;
        joystickOutline.position = _clickedPosition;
        
        ShowJoystick();
    }
    
    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
        _canControl = true;
    }
    
    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        _canControl = false;
        _move = Vector3.zero;
    }
    
    private void ControlJoystick()
    {
        var currentPosition = Input.mousePosition;
        var direction = currentPosition - _clickedPosition;
        
        var moveMagnitude = direction.magnitude * moveFactor / Screen.width;
        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);
        
        _move = direction.normalized * moveMagnitude;
        var targetPosition = _clickedPosition + _move;
        
        joystickKnob.position = targetPosition;

        if(Input.GetMouseButtonUp(0))
            HideJoystick();
    }
    
    public Vector3 GetMoveVector()
    {
        return _move;
    }
    
}
