using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
    Rigidbody rigid_body;

	// Use this for initialization
	void Start () {
        rigid_body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        OnKeyPress();
		
	}

    private void OnKeyPress()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigid_body.AddRelativeForce(Vector3.up);
            print("space");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward);
            print("right");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
            print("left");
        }
    }
}
