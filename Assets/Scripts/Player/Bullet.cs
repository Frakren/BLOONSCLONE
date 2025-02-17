﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Monkey parent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<AIEnemy>().ApplyDamage(parent.damage);
            Destroy(gameObject);
        }
    }
}
