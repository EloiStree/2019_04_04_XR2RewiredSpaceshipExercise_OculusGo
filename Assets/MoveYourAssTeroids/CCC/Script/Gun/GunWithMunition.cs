using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWithMunition : DefaultGun
{
    public int m_munitionLeft=1;

    public override void SpawnBullet()
    {
        if (base.IsAllowToFire() && m_munitionLeft > 0) {
            base.SpawnBullet();
            m_munitionLeft--;
        }
        
    }
}
