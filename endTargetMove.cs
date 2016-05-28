using UnityEngine;
using System.Collections;

public class endTargetMove : MonoBehaviour {


    public GameObject playerTarget;
    public GameObject endTarget;

    private Vector3 offset;




    // Use this for initialization
    void Start()
    {

        offset = new Vector3(
            endTarget.transform.position.x - playerTarget.transform.position.x,
            endTarget.transform.position.y - playerTarget.transform.position.y,
            endTarget.transform.position.z - playerTarget.transform.position.z);



    }

    // Update is called once per frame
    void LateUpdate()
    {

        endTarget.transform.position = new Vector3(
            playerTarget.transform.position.x + offset.x,
            playerTarget.transform.position.y + offset.y,
            playerTarget.transform.position.z + offset.z);


  

    }
}
