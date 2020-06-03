using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    public float xPos;
    public float zPos;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the 
        xPos = Random.Range(-1.0f, 1.0f);
        zPos = Random.Range(-1.0f, 1.0f);
        movementDirection = new Vector2(xPos, zPos).normalized;
        movementPerSecond = movementDirection * characterVelocity;
        transform.rotation = Quaternion.Euler(xPos, 0, zPos);
    }

    // Update is called once per frame
    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

    }
}