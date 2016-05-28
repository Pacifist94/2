using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

    public bool xAxisRight = false;

    public static bool collisionDetected = false;
    public static bool arrowright = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter(Collider other) {

        if (xAxisRight)
        {

            if (other.gameObject.name == "MainPlayer")
            {
                
                arrowright = true;
                collisionDetected = true;
            }

        }
        else
        {
            if (other.gameObject.name == "MainPlayer")
            {
                arrowright = false;
                collisionDetected = true;
            }

        }
        

    }
}
