using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform myTransform;
    public Transform target;
    int moveSpeed = 1;
    int rotationSpeed = 2;
    int stop = 0;
    float range = 10f;
    private GameObject prefab;
    public float shellSpeed = 200f;
    public float fireRate = 1f;
    private float nextFire;
    

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Shell 1") as GameObject;
        target = GameObject.FindWithTag("Player").transform;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(myTransform.position, target.position);
        
        if (distance <= range)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

            if (distance > stop)
            {
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                Shoot();
            }
        }

        
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var shell = Instantiate(prefab, transform.position + transform.forward, Quaternion.identity);
            shell.GetComponent<Rigidbody>().AddForce(transform.forward * shellSpeed);
            nextFire = Time.time + fireRate;
            Destroy(shell, 1.5f);
        }
    }
    
}
    
