using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


    
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
       
       offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {

        //    transform.position = player.transform.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothTime);

    }



    void Update()
    {
        
        
    }

}
