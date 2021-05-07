using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pt;

    

    // Update is called once per frame
    void Update()
    {
        Vector3 ct = new Vector3(pt.position.x, pt.position.y, -10);
        transform.position = ct;
    }
}
