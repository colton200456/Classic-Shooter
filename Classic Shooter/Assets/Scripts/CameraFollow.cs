using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float angle;
    public float height;

    	// Use this for initialization
	void Start () {
		
	}
	
	void LateUpdate () {
        //transform.position = target.transform.position;
        //transform.position -= Vector3.forward * angle;
        //transform.position = new Vector3(transform.position.x, height, transform.position.z);
        //transform.LookAt(target.transform.position);
	}
}
