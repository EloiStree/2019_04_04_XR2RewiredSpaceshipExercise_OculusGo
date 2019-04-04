using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransformPosition : MonoBehaviour
{
    public Transform m_toFollow;
    public Transform m_toAffect;

    public bool m_useLerp=true;
    [Range(0,4)]
    public float m_lerpPower=1f;
    public bool m_usePosition=true;
    public bool m_useRotation=true;
    
    void LateUpdate()
    {
        if (m_toFollow == null)
            m_toFollow = CheckForValidePointToFollow();
        if (m_useLerp)
        {
            if(m_usePosition)
                m_toAffect.position = Vector3.Lerp(m_toAffect.position, m_toFollow.position, Time.deltaTime * m_lerpPower);

            if (m_useRotation)
                m_toAffect.rotation = Quaternion.Lerp(m_toAffect.rotation, m_toFollow.rotation, Time.deltaTime * m_lerpPower);
        }
        else
        {
            if (m_usePosition)
                m_toAffect.position = m_toFollow.position;

            if (m_useRotation)
                m_toAffect.rotation =  m_toFollow.rotation;
        }
    }

    protected virtual Transform CheckForValidePointToFollow()
    {
        return null;
    }

    private void Reset()
    {
        m_toAffect = transform;
    }
}

