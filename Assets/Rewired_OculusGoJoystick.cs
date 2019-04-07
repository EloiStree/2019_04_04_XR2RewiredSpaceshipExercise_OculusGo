using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewired_OculusGoJoystick : MonoBehaviour
{
    public string playerId = "Player";
    public string controllerId = "OculusGO";
    private Player player;


    void Start()
    {

        if (ReInput.players == null || ReInput.players.playerCount <= 0)
            return;
        player = ReInput.players.GetPlayer(playerId);

        if (player == null)
            return;
        for (int i = 0; i < player.controllers.customControllerCount; i++)
        {
            CustomController controller = player.controllers.CustomControllers[i];
            // Debug.Log("Controller:"+ controller.hardwareName);
            if (controller.hardwareName == controllerId)
            {
                controller.SetAxisUpdateCallback(GetAxisInfo);
                controller.SetButtonUpdateCallback(GetButtonInfo);
                //   Debug.Log("Hey mon ami");
            }

        }
    }

    protected bool GetButtonInfo(int buttonId) {
        switch (buttonId)
        {
            //Triggering
            case 0: return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
            //PadTouching
            case 1: return OVRInput.Get(OVRInput.Button.PrimaryTouchpad);
            //PadClicking
            case 2: return OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
            //escape
            case 3: return OVRInput.Get(OVRInput.Button.Back);
            //longescape
            case 4: return OVRInput.Get(OVRInput.Button.Back) && m_timePressingEscape > m_timeToBePressing;
            default:
                return false;
        }
    }
    protected float GetAxisInfo(int axisId) {
        Vector2 touchAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        float trigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) ? 1f : 0f;
        switch (axisId)
        {
            case 0: return Mathf.Abs(touchAxis.x);
            case 1: return Mathf.Abs(touchAxis.y);
            case 2: return trigger;
            default:
                return 0f;
        }
    }

    public float m_timeToBePressing = 2;
    public float m_timePressingEscape;
    public void Update()
    {
        bool isEscapePressing = OVRInput.Get(OVRInput.Button.Back);
        if (isEscapePressing)
            m_timePressingEscape += Time.deltaTime;
        else m_timePressingEscape = 0f;
        
    }
}
