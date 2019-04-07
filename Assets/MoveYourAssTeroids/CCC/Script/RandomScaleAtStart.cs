using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaleAtStart : MonoBehaviour
{
    public Vector3 m_scaleSizeMin = new Vector3(1, 2, 1);
    public Vector3 m_scaleSizeMax = new Vector3(1, 5, 1);

    void Start()
    {
        transform.localScale = GetRandomScale(transform.localScale);
    }

    private Vector3 GetRandomScale(Vector3 localScale)
    {
        localScale.x *= UnityEngine.Random.Range(m_scaleSizeMin.x, m_scaleSizeMax.x);
        localScale.y *= UnityEngine.Random.Range(m_scaleSizeMin.y, m_scaleSizeMax.y);
        localScale.z *= UnityEngine.Random.Range(m_scaleSizeMin.z, m_scaleSizeMax.z);
        return localScale;
    }
    
}
