using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : Gun
{
    public float m_cooldown = 1;
    public float m_cooldownState = 0;


    protected virtual void Update()
    {
        DecreaseCooldown();
    }

  
    public override void SpawnBullet()
    {
        if (IsAllowToFire())
        {
            GameObject bullet = (GameObject)Instantiate(m_bulletPrefab, m_spawnPoint.position , m_spawnPoint.rotation);
            m_cooldownState = m_cooldown;
        }
    }




    private void DecreaseCooldown()
    {
        if (m_cooldownState >= 0)
        {
            m_cooldownState -= Time.deltaTime;
            if (m_cooldownState < 0)
            {
                m_cooldownState = 0;
            }
        }
    }



    protected override void OnWeaponChangeState(bool newState)
    {
        if (newState)
        {
            SpawnBullet();
        }
    }

    public override bool IsAllowToFire()
    {
        return m_state && m_cooldownState <= 0f;
    }
}