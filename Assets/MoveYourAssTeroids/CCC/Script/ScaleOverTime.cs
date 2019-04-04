using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    public AnimationCurve m_scaleCurve;

    public Vector3 m_originalScale;
    public float m_curveMultiplicator=3;
    public float m_timeSinceCreated ;
    void Start()
    {
        m_originalScale = transform.localScale;
        
    }
    void Update()
    {
        m_timeSinceCreated += Time.deltaTime;
      transform.localScale = m_originalScale * m_curveMultiplicator * m_scaleCurve.Evaluate(m_timeSinceCreated);
        
    }
}
