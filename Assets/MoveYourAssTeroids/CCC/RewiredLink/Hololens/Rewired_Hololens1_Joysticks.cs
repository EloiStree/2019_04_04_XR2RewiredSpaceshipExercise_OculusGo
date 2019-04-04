using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewired_Hololens1_Joysticks : MonoBehaviour
{
    public string playerId = "Player";
    public string controllerId = "Hololens1";
    private Player player;


    [Header("Hand Tracked")]
    public Transform m_handLeftTracked;
    public Transform m_handRightTracked;
    [Header("Camera view")]
    public Transform m_cameraViewTracked;
    public Transform m_startLeftHandZone;
    public Transform m_endLeftHandZone;
    public Transform m_startRightHandZone;
    public Transform m_endRightHandZone;


    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);

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

    protected bool GetButtonInfo(int buttonId) {

        return false;
    }
    public Vector3 joystickLeft;
    public Vector3 joystickRight;
    private Vector3 test, test2;
    protected float GetAxisInfo(int axisId)
    {
        joystickLeft = GetJoystickLeft(m_handLeftTracked, m_startLeftHandZone, m_endLeftHandZone);
        joystickRight = GetJoystickLeft(m_handRightTracked, m_startRightHandZone, m_endRightHandZone);
        switch (axisId)
        {
            case 0: return joystickLeft.x;
            case 1: return joystickLeft.y;
            case 2: return joystickLeft.z;
            case 3: return joystickRight.x;
            case 4: return joystickRight.y;
            case 5: return joystickRight.z;
            default:
                return 0f;
        }
    }

    private Vector3 GetJoystickLeft(Transform hand, Transform startHandZone, Transform endHandZone)
    {
        Vector3 result;
        Vector3 start = RepositionToCamera(startHandZone);
        Vector3 end = RepositionToCamera(endHandZone);
        float horizontalRadius = startHandZone.lossyScale.x /2f;
        float verticalRadius = startHandZone.lossyScale.y/2f;
        float depth = Vector3.Distance(start, end);

        Vector3 hl  = RepositionTo(hand, startHandZone);
        test = hl;
        test2.x = horizontalRadius;
        test2.y = verticalRadius;
        test2.z = depth;

        result.y = Mathf.Clamp(hl.y / verticalRadius,-1,1);
        result.x = Mathf.Clamp(hl.x / horizontalRadius,-1,1);
        result.z = Mathf.Clamp(hl.z / depth,0,1);

        return result;
    }

    public Vector3 RepositionToCamera(Transform point)
    {
        return m_cameraViewTracked.InverseTransformPoint(point.position);
    }
    public Vector3 RepositionTo(Transform point, Transform newPlan)
    {
        Vector3 post = Quaternion.Inverse(newPlan.rotation) * (point.position - newPlan.position);

        return post;
    }
}
