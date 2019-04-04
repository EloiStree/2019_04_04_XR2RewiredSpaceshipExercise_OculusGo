using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    public float m_time=2;
    void Start()
    {
        Destroy(this.gameObject, m_time);
    }
}
