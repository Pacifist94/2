using UnityEngine;
using System.Collections;

public class scriptDestroy : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barricade")
        {
            
            Destroy(other.gameObject);

                
        }
        else if (other.tag == "Destructible" || other.tag == "Star")
        {
            Destroy(other.gameObject);

        }
        else if (other.tag == "moveForward")
        {
       
            other.transform.position= new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - (252.1475f * 3));
        }
        else if (other.tag == "moveForwardBorder")
        {

            // other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - (250.0f * 3));
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - (252.1475f * 3));
        }
        

    }

  

}
