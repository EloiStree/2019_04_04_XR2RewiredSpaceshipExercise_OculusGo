using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public GameObject m_bulletPrefab;
    public Transform m_spawnPoint;
    public bool m_state;


    public abstract void SpawnBullet();
    public abstract bool IsAllowToFire();




    public void SetState(bool state) {
        bool oldState =m_state, newState = state;
        m_state = state;
        if (oldState!= newState)
            OnWeaponChangeState(newState);

    }
    protected abstract void OnWeaponChangeState(bool newState);
}


