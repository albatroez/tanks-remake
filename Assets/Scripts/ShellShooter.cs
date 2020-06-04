using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellShooter : MonoBehaviour
{
    private GameObject prefab;
    private float nextFire;
    public int damage = 50;
    public float shellSpeed = 500f;
    public float fireRate = 1f;
    public AudioClip impact;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Shell") as GameObject;
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            audioSource.PlayOneShot(impact);

            var shell = Instantiate(prefab, transform.position + transform.forward*1.5f, Quaternion.identity);
            shell.GetComponent<Rigidbody>().AddForce(transform.forward * shellSpeed);
            nextFire = Time.time + fireRate;
            Destroy(shell, 2f);
        }
        
    }

}
