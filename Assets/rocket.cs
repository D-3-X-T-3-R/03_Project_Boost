using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
    Rigidbody rigid_body;
    AudioSource audio_source;
    public float spin = 100f;
    public float thrust = 100f;

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

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "safe":
                print ("safe");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void Rotate()
    {
        var rotation_speed = spin * Time.deltaTime;
        rigid_body.freezeRotation = true;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward*rotation_speed);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward*rotation_speed);
            
        }
        //rigid_body.freezeRotation = false;
    }

    private void Thrust()
    {
        var thrust_speed = thrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {

            rigid_body.AddRelativeForce(Vector3.up*thrust_speed);
            if (!audio_source.isPlaying)
            {
                audio_source.Play();
            }
            
        }
        else
        {
            audio_source.Stop();
        }
    }
}
