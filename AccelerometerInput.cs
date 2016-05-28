using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {


    public int speed; // speed of father

    public Text xValue; //Labeling
    public Text yValue;
    public Text zValue;

    private Rigidbody rb;

     void Start()
    {
        rb = GetComponent <Rigidbody>();

    }

      void FixedUpdate()
    {
      /* transform.Translate(Input.acceleration.x * speed, 0.0f, Input.acceleration.y * speed);
     
    
      //   xValue.text ="x: " + System.Math.Round((Input.acceleration.x), 2, System.MidpointRounding.AwayFromZero); //System.Convert.ToString(Input.acceleration.x);
      //   yValue.text = "y: " + System.Math.Round((Input.acceleration.y), 2, System.MidpointRounding.AwayFromZero);// System.Convert.ToString(Input.acceleration.y);
      //   zValue.text = "z: " + System.Math.Round((Input.acceleration.z), 2, System.MidpointRounding.AwayFromZero); //System.Convert.ToString(Input.acceleration.z);

      Vector3 movement = new Vector3(Input.acceleration.x * speed, 0.0f, Input.acceleration.y * speed);

      rb.AddForce(movement);

      */
    }
}
