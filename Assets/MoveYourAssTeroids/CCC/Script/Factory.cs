using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Factory : MonoBehaviour
{
    public GameObject [] m_objectPool;
    public Transform m_spawnCenter;
    public float m_maxRange = 5;
    public float m_minTimeBetweenSpawn = 0.1f;
    public float m_maxTimeBetweenSpawn = 3f;

    public float m_minSize = 1;
    public float m_maxSize = 5;

    public float m_minSpeed = 10;
    public float m_maxSpeed = 30;

    public CreatedObjectEvent onCreatedObject;
    [System.Serializable]
    public class CreatedObjectEvent : UnityEvent<GameObject> {

    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_minTimeBetweenSpawn, m_maxTimeBetweenSpawn));
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate( GetRandomPrefab());
        
        obj.transform.position = GetRandomPosition();
        obj.transform.rotation = m_spawnCenter.rotation;
        obj.transform.localScale = Vector3.one * GetRandomFloat(m_minSize, m_maxSize);
        MoveForward moveForward = obj.GetComponent<MoveForward>();
        if (moveForward == null)
        {
            moveForward = obj.gameObject.AddComponent<MoveForward>();
            moveForward.m_affected = obj.transform;
        }
        moveForward.m_speed = GetRandomFloat(m_minSpeed, m_maxSpeed);
        onCreatedObject.Invoke(obj);
    }

    private float GetRandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 random = m_spawnCenter.lossyScale;
        random.x *= Random.Range(-1f, 1f);
        random.y *= Random.Range(-1f, 1f);
        random.z *= Random.Range(-1f, 1f);
        Vector3 newPosition = m_spawnCenter.position + ( m_spawnCenter.rotation * random );

        return newPosition;
    }

    private GameObject GetRandomPrefab()
    {
        return m_objectPool[UnityEngine.Random.Range( 0, m_objectPool.Length)];
    }

    private void Reset()
    {
        m_spawnCenter = transform;
    }
}
