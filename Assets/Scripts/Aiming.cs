using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;
        Vector3 lookAtPosition = new Vector3(mouseRay.origin.x + mouseRay.direction.x, mouseRay.origin.y + mouseRay.direction.y, this.transform.position.z);
        transform.LookAt(lookAtPosition);
    }
    
    
}
