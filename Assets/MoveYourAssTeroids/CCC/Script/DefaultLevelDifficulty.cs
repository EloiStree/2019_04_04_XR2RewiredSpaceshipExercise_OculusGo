using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLevelDifficulty : MonoBehaviour
{

    public AnimationCurve m_generalSpawnIntensity;
    public AnimationCurve m_generalSpeedIntensity;
    public float m_aditionalSpeed = 100;
    public float m_minSpawnTime = 0.3f;
    public float m_initialSpawnTime = 4f;
    public float m_minSpeed=30;
    public Factory [] m_factories;
    public float m_maxSurvivaleTime = 300;

    void Update()
    {

        foreach (Factory factory in m_factories)
        {
            factory.m_minSpeed = factory.m_maxSpeed = m_minSpeed + ( m_aditionalSpeed * m_generalSpeedIntensity.Evaluate((Time.timeSinceLevelLoad/ m_maxSurvivaleTime)));
            factory.m_maxTimeBetweenSpawn = m_minSpawnTime + m_initialSpawnTime * m_generalSpawnIntensity.Evaluate((Time.timeSinceLevelLoad / m_maxSurvivaleTime));
        }
    }
}
