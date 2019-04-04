using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewired_HandsAsJoystick_UI : Rewired_HandsAsJoystick
{

    public Slider m_leftHandX;
    public Slider m_leftHandY;
    public Slider m_leftHandZ;

    public Slider m_rightHandX;
    public Slider m_rightHandY;
    public Slider m_rightHandZ;



    public Toggle m_triggerLeft;
    public Toggle m_grabbingLeft;

    public Toggle m_triggerRight;
    public Toggle m_grabbingRight;

    protected override float GetAxisInfo(int axisId)
    {
        switch (axisId)
        {
            case 0: return m_leftHandX.value;
            case 1: return m_leftHandY.value;
            case 2: return m_leftHandZ.value;
            case 3: return m_rightHandX.value;
            case 4: return m_rightHandY.value;
            case 5: return m_rightHandZ.value;
            default:
                return 0f;
        }
    }

    protected override bool GetButtonInfo(int buttonId)
    {
        switch (buttonId)
        {
            case 0: return m_triggerLeft.isOn;
            case 1: return m_grabbingLeft.isOn;
            case 2: return m_triggerRight.isOn;
            case 3: return m_grabbingRight.isOn;
            default:
                return false;
        }
    }
}
