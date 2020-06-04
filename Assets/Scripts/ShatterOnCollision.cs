using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollision : MonoBehaviour
{
    public GameObject replacement;

    private string[] TagList = {"Bullet", "Player", "Enemy"};
    private void OnCollisionEnter(Collision other)
    {
        foreach (string testTag in TagList)
        {
            if (other.gameObject.CompareTag(testTag))
            {
                GameObject.Instantiate(replacement, transform.position + Vector3.down, transform.rotation);
                Destroy(gameObject);
            }
        }
        
        
    }
}
