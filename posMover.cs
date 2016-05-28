using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class posMover : MonoBehaviour {


    public GameObject playerTarget;
    public GameObject PosTarget;

    private Vector3 offset;




    // Use this for initialization
    void Start () {

         offset = new Vector3(
             PosTarget.transform.position.x - playerTarget.transform.position.x, 
             PosTarget.transform.position.y - playerTarget.transform.position.y, 
             PosTarget.transform.position.z - playerTarget.transform.position.z);



    }
	
	// Update is called once per frame
	void LateUpdate () {

        PosTarget.transform.position = new Vector3(
            2.3f, 
            playerTarget.transform.position.y + offset.y, 
            playerTarget.transform.position.z + offset.z);


         

    }


}
