using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellShooter : MonoBehaviour
{
    private GameObject prefab;
    private float nextFire;

    public float shellSpeed = 500f;
    public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Shell") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            var shell = Instantiate(prefab, transform.position + transform.forward, Quaternion.identity);
            shell.GetComponent<Rigidbody>().AddForce(transform.forward * shellSpeed);
            nextFire = Time.time + fireRate;
            Destroy(shell, 1.5f);
        }
        
    }

}
