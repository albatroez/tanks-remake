using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggernEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SendMessage("OnDamage", damage);
        }
    }
}
