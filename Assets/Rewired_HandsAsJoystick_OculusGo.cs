using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewired_HandsAsJoystick_OculusGo : Rewired_HandsAsJoystick
{
    //https://developer.oculus.com/documentation/unity/latest/concepts/unity-ovrinput/
    protected override float GetAxisInfo(int axisId)
    {
       Vector2 touchAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        switch (axisId)
        {
            case 0: return -Mathf.Abs(touchAxis.x);
            case 1: return touchAxis.y;
            case 2: return 0f;
            case 3: return -Mathf.Abs(touchAxis.x);
            case 4: return touchAxis.y;
            case 5: return 0f;
            default:
                return 0f;
        }
    }

    protected override bool GetButtonInfo(int buttonId)
    {
        switch (buttonId)
        {
            case 0: return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
            case 1: return OVRInput.Get(OVRInput.Button.PrimaryTouchpad);
            case 2: return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
            case 3: return OVRInput.Get(OVRInput.Button.PrimaryTouchpad);
            default:
                return false;
        }
    }
}
