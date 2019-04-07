using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rewired_HandsAsJoystick : MonoBehaviour
{
    public string playerId = "Player";
    public string controllerId = "HandsAsJoystick";
    private Player player;


    void Start()
    {

        if (ReInput.players==null ||  ReInput.players.playerCount <=0)
            return;
        player = ReInput.players.GetPlayer(playerId);

        if (player == null)
            return;
        for (int i = 0; i < player.controllers.customControllerCount; i++)
        {
            CustomController controller = player.controllers.CustomControllers[i];
           // Debug.Log("Controller:"+ controller.hardwareName);
            if (controller.hardwareName == controllerId) {
                controller.SetAxisUpdateCallback(GetAxisInfo);
                controller.SetButtonUpdateCallback(GetButtonInfo);
             //   Debug.Log("Hey mon ami");
            }

        }
    }

    protected abstract bool GetButtonInfo(int buttonId);
    protected abstract float GetAxisInfo(int axisId);
    
}
