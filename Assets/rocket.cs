using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
    Rigidbody rigid_body;
    AudioSource audio_source;
    // Use this for initialization
    void Start () {
        rigid_body = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Rotate();
        Thrust();
    }

    private void Rotate()
    {
        rigid_body.freezeRotation = true;
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
        rigid_body.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rigid_body.AddRelativeForce(Vector3.up);
            if (!audio_source.isPlaying)
            {
                audio_source.Play();
            }
            print("space");
        }
        else
        {
            audio_source.Stop();
        }
    }
}
