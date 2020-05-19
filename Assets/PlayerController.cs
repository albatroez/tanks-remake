using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float walkSpeed = 2;
    public float scrollScale = 0.8f;
    private Rigidbody rigidbody;
    private Camera camera;

    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    { 
        HandleRiding();
        HandleZoom();
    }

 /*   private void HandleVerticalRotation()
    {
        var mouseVerticalRotation = Input.GetAxis("Mouse Y");
        var camRot = camera.transform.rotation.eulerAngles;
        camRot.x = camRot.x - mouseVerticalRotation;
        camera.transform.rotation = Quaternion.Euler(camRot);
    }

    private void HandleHorizontalRotation()
    {
        var mouseHorizontalRotation = Input.GetAxis("Mouse X");
        var newRotation = transform.localRotation.eulerAngles;
        newRotation.y = newRotation.y + mouseHorizontalRotation;
        transform.localRotation = Quaternion.Euler(newRotation);
    }*/

 private void HandleZoom()
 {
     var newPosition = camera.transform.position;
     newPosition.y += Input.mouseScrollDelta.y * scrollScale;
     if (newPosition.y > 10 && newPosition.y < 50)
        camera.transform.position = newPosition;
 }

    private void HandleRiding()
    {
        var userKeyboardInput = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        var velocity = transform.rotation * userKeyboardInput * walkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = velocity * 2;
        }
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
    
    
}
