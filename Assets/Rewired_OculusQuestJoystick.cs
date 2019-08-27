using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewired_OculusQuestJoystick : MonoBehaviour
{
    public string playerId = "Player";
    public string controllerId = "OculusQuest";
    private Player player;

    public bool m_useEditorDebug = true;

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
            if (controller.hardwareName == controllerId)
            {
                controller.SetAxisUpdateCallback(GetAxisInfo);
                controller.SetButtonUpdateCallback(GetButtonInfo);
            }

        }
    }

    protected bool GetButtonInfo(int buttonId)
    {
        switch (buttonId)
        {

            case 4: return OVRInput.Get(OVRInput.Button.Four) ;
            case 5: return OVRInput.Get(OVRInput.Button.Three) ;
            case 6: return OVRInput.Get(OVRInput.Button.Two);
            case 7: return OVRInput.Get(OVRInput.Button.One);
            case 8: return OVRInput.Get(OVRInput.Button.Back);
        }

        return false;
    }
 
    protected float GetAxisInfo(int axisId)
    {
        switch (axisId) {
            
            case 6: return OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
            case 7: return OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
            case 8: return OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
            case 9: return OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
            case 10: return OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) ;
            case 11: return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) ;
            case 12: return OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
            case 13: return OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) ;
        }

        return 0f;
    }

  
    //public float m_timeToBePressing = 2;
    //public float m_timePressingEscape;
    //public void Update()
    //{
    //    bool isEscapePressing = OVRInput.Get(OVRInput.Button.Back);
    //    if (isEscapePressing)
    //        m_timePressingEscape += Time.deltaTime;
    //    else m_timePressingEscape = 0f;

    //}
}
