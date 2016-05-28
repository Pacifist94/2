using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public int speed ; // 30 Default

    private Rigidbody rb;


    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update () {


        //Moves the red scripted father to infront

        if (CollisionDetector.death == false)
        {
            rb.velocity = -transform.forward * speed;
            transform.Translate(0.0f, 0.0f, 0.0f);

            Debug.Log("Executing");
        }
        else
        {

            rb.velocity = -transform.forward * 0 ;
        }

        

        // moves the RedScriptedFather according to Accell
        //  transform.Translate(-Input.acceleration.x * speed, 0.0f, 0.0f);


        /* Vector3 movement = new Vector3(Input.acceleration.x * speed, 0.0f, 0.0f);

          rb.AddForce(movement);
          */

    }

    
}
