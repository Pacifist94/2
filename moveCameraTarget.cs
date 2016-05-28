using UnityEngine;
using System.Collections;

public class moveCameraTarget : MonoBehaviour {

    public GameObject playerTarget;
    Vector3 offset;

    void Start()
    {

    //    offset = new Vector3(
      //      transform.position.x - playerTarget.transform.position.x, 0, 0);
          //PosTarget.transform.position.y - playerTarget.transform.position.y,
           // PosTarget.transform.position.z - playerTarget.transform.position.z);



    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = new Vector3(playerTarget.transform.position.x + offset.x,
            transform.position.y,
            transform.position.z);


       

    }

}
