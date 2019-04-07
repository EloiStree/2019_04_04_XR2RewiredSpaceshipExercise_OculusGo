using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewired_OculusGoJoystick : MonoBehaviour
{
    public string playerId = "Player";
    public string controllerId = "OculusGo";
    private Player player;

    public bool m_useEditorDebug=true;

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
            case 1: return OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
            //PadClicking
            case 2: return OVRInput.Get(OVRInput.Button.PrimaryTouchpad);
            //escape
            case 3: return OVRInput.Get(OVRInput.Button.Back);
            //longescape
            case 4: return OVRInput.Get(OVRInput.Button.Back) && m_timePressingEscape > m_timeToBePressing;
          
            default:
                return false;
        }
    }
     Quaternion rot;
     Vector3 euleuRot;
     Vector3 pitchYawRoll;
    protected float GetAxisInfo(int axisId) {
      OVRInput.Controller active =  OVRInput.GetActiveController();
      rot = OVRInput.GetLocalControllerRotation(active);

         euleuRot= rot.eulerAngles;
#if UNITY_EDITOR
        if (m_useEditorDebug)
            euleuRot = transform.eulerAngles;
#endif
        pitchYawRoll= ConvertEuleurToJoystick(euleuRot);
        Vector2 touchAxis  = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        float trigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) ? 1f : 0f;
        switch (axisId)
        {
            case 0: return (touchAxis.x);
            case 1: return (touchAxis.y);
            case 2: return trigger;
            case 3: return pitchYawRoll.x ;
            case 4: return pitchYawRoll.y ;
            case 5: return pitchYawRoll.z;
            default:
                return 0f;
        }
    }

    private Vector3 ConvertEuleurToJoystick(Vector3 euleuRot)
    {
        euleuRot.x = -ConvertAsJosytickFloat(euleuRot.x);
        euleuRot.y = -ConvertAsJosytickFloat(euleuRot.y);
        euleuRot.z = ConvertAsJosytickFloat(euleuRot.z);
        return euleuRot;

    }

    private static float ConvertAsJosytickFloat(float value)
    {
        if (value > 180f)
        {
            value -= 360f;
            value /= 180f;

        }
        else value /= 180f;
        return value;
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
