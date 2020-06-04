using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public float rideSpeed = 2f;
    public float scrollScale = 0.8f;
    
    private Vector3 velocity;
    private Rigidbody rigidbody;

    public int maxHealth = 100;
    public int currrentHealth;
    public HealthBar healthBar;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currrentHealth = maxHealth;
        healthBar.SetMaxValue(100);
    }

    void Update()
    { 
        HandleRiding();
        //HandleZoom();
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            transform.forward = Vector3.Normalize(velocity);
        }
        
        rigidbody.velocity = velocity;
    }

    /*
    private void HandleZoom()
     {
         var newPosition = camera.transform.position;
         newPosition.y += -Input.mouseScrollDelta.y * scrollScale;
         if (newPosition.y > 10 && newPosition.y < 50)
            camera.transform.position = newPosition;
     }
     */

    private void HandleRiding()
    {
        var userKeyboardInput = new Vector3(
            Input.GetAxis("Horizontal"),
            0f,
            Input.GetAxis("Vertical")
        );
        velocity = userKeyboardInput.normalized * rideSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = velocity * 1.5f;
        }
    }

    void TakeDamage(int damage)
    {
        currrentHealth -= damage;
        healthBar.SetHealth(currrentHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
            health -= 20;
            if (health <= 0)
            {

                Destroy(gameObject);
            }
        } 
    }
}
