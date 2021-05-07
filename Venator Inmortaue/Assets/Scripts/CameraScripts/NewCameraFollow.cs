using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public Camera cam;
    public float dist;

    public float Speed;
    public Vector3 target;
    public Vector3 mouse;
    void Update()
    {

        



        
        float xDif = this.transform.position.x - ObjectToFollow.transform.position.x;
        float yDif = this.transform.position.y - ObjectToFollow.transform.position.y;



        if (xDif > 1.5f)
        {
            this.transform.position = new Vector3(ObjectToFollow.transform.position.x + 1.5f,
                this.transform.position.y, this.transform.position.z);
        }
        else if (xDif < -1.5f)
        {
            this.transform.position = new Vector3(ObjectToFollow.transform.position.x - 1.5f,
                this.transform.position.y, this.transform.position.z);
        }

        if (yDif > 1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, ObjectToFollow.transform.position.y + 1.5f,
                this.transform.position.z);
        }
        else if (yDif < -1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, ObjectToFollow.transform.position.y - 1.5f,
                this.transform.position.z);
        }
        







    }

    public float trigDist;

    void FixedUpdate()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        target.x = Mathf.Lerp(ObjectToFollow.transform.position.x, mouse.x, 0.5f);
        target.y = Mathf.Lerp(ObjectToFollow.transform.position.y, mouse.y, 0.5f);
        target.z = this.gameObject.transform.position.z;

        //calculates the distance between the player and the mouse
        dist = Mathf.Sqrt((mouse.x - ObjectToFollow.transform.position.x) * (mouse.x - ObjectToFollow.transform.position.x) +
            (mouse.y - ObjectToFollow.transform.position.y) * (mouse.y - ObjectToFollow.transform.position.y));


        if (dist > trigDist)
        {
            
            float interpolation = Speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, target.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, target.x, interpolation);

            this.transform.position = position;


            




            



        }
        else
        {
            float interpolation = Speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, ObjectToFollow.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, ObjectToFollow.transform.position.x, interpolation);

            this.transform.position = position;

        }
    }
}
