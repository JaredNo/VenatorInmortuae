using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class BetterCameraFollow : MonoBehaviour
{
    
    public GameObject ObjectToFollow;
    

    public float Speed;
    
    
    void Update()
    {
        
        




        float xDif = this.transform.position.x - ObjectToFollow.transform.position.x;
        float yDif = this.transform.position.y - ObjectToFollow.transform.position.y;



        if (xDif > 1.5f)
        {
            this.transform.position = new Vector3(ObjectToFollow.transform.position.x + 1.5f,
                this.transform.position.y, this.transform.position.z);
        }else if (xDif < -1.5f)
        {
            this.transform.position = new Vector3(ObjectToFollow.transform.position.x - 1.5f,
                this.transform.position.y, this.transform.position.z);
        }

        if(yDif > 1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, ObjectToFollow.transform.position.y + 1.5f,
                this.transform.position.z);
        }else if(yDif < -1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, ObjectToFollow.transform.position.y - 1.5f,
                this.transform.position.z);
        }
        
        

        

        
    }

    

    void FixedUpdate()
    {
        
        float interpolation = Speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, ObjectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, ObjectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
        
    }
}
