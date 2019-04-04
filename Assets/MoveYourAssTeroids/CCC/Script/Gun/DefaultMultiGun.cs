using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMultiGun : Gun
{
    public Gun[] m_guns;

    public override bool IsAllowToFire()
    {
        return true;
    }

    public override void SpawnBullet()
    {

        return;
    }

    protected override void OnWeaponChangeState(bool newState)
    {
        for (int i = 0; i < m_guns.Length; i++)
        {
            m_guns[i].SetState(m_state);
        }
    }
}
