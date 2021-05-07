using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchToCamera : MonoBehaviour
{

    public Transform cam;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(cam.position.x, cam.position.y, 0);
        transform.position = pos;
    }
}
