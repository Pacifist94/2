﻿using UnityEngine;
using System.Collections;

public class StarRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
        transform.Rotate(Vector3.up, 10);
      
    }


}
