using UnityEngine;
using System.Collections;

public class Breathe : MonoBehaviour {

    Vector3 startPos;

    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad*10);
        transform.position = startPos + Vector3.up * distance;
    }
}
