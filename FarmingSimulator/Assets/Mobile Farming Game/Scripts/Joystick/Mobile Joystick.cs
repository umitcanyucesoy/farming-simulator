using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header("----- ELEMENTS ------")] 
    [SerializeField] private RectTransform joystickOutline;

    public void ClickedOnJoystickZoneCallback()
    {
        var clickedPosition = Input.mousePosition;
        joystickOutline.position = clickedPosition;
    }
    
    
}
