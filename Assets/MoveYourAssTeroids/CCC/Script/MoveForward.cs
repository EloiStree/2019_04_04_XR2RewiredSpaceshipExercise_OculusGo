using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float m_speed=5;
    public Transform m_affected;

    void Update()
    {
        m_affected.Translate(Vector3.forward * m_speed*Time.deltaTime, Space.Self);
        
    }
    public void Reset()
    {
        m_affected = this.transform;
    }
}
