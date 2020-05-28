using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollision : MonoBehaviour
{
    public GameObject replacement;

    private void OnCollisionEnter(Collision other)
    {
        GameObject.Instantiate(replacement, transform.position + Vector3.down, transform.rotation);
        
        Destroy(gameObject);
    }
}
