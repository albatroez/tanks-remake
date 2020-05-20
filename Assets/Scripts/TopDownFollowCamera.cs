using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTarget;
    public Vector3 targetOffset;
    public float moveSpeed = 2f;
	
    private Transform _myTransform;

    private void Start () {
        // Cache camera transform
        _myTransform = transform;	
    }
	
    public void SetTarget ( Transform aTransform ) {
        followTarget = aTransform;	
    }

    private void LateUpdate () {
        if(followTarget != null)
            _myTransform.position = Vector3.Lerp( _myTransform.position, followTarget.position + targetOffset, moveSpeed * Time.deltaTime );
    }

}
