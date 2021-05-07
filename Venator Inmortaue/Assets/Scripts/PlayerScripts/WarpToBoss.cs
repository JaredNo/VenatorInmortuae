using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpToBoss : MonoBehaviour
{
    public Transform pt;
    public Vector3 PosToWarpTo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            pt.position = PosToWarpTo;
        }

    }
}
