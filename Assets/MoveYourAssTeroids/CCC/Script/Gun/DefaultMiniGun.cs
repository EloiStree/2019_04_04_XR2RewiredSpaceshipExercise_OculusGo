using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMiniGun : DefaultGun
{

    protected override void Update()
    {
        base.Update();
        if (m_state)
            SpawnBullet();
    }

}