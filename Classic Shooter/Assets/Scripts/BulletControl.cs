using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float rx = Input.GetAxis("RightStickHorizontal");
        float ry = Input.GetAxis("RightStickVertical");

        if (rx > .2) {
            rx = 5;
        }
        if (rx < -.2) {
            rx = -5;
        }
        if (ry > .2) {
            ry = 5;
        }
        if (ry < -.2) {
            ry = -5;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(rx, ry,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
