﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
