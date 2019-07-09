using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour {
    Rigidbody rigid_body;
    AudioSource audio_source;
    public float spin = 100f;
    public float thrust = 100f;

    public AudioClip audio_clip_thrust;
    public AudioClip audio_clip_win;
    public AudioClip audio_clip_collide;

    public ParticleSystem particle_thrust;
    public ParticleSystem particle_win;
    public ParticleSystem particle_collide;

    enum State{Alive,Transition,Dead};
    int level = 0;
    State current_state = State.Alive;
    // Use this for initialization
    void Start () {
        rigid_body = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (current_state == State.Alive)
        {
            Rotate();
            Thrust();
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (current_state != State.Alive)
        {
            particle_thrust.Stop();
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "safe":
                current_state = State.Alive;
                break;
            case "Finish":
                LevelCompleteSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    }

    private void DeathSequence()
    {
        
        audio_source.Stop();
        audio_source.PlayOneShot(audio_clip_collide);
        current_state = State.Dead;
        particle_collide.Play();
        Invoke("LoadLevelDead", 2f);
        level = 0;
    }

    void LevelCompleteSequence()
    {
        audio_source.Stop();
        audio_source.PlayOneShot(audio_clip_win);
        current_state = State.Transition;
        particle_win.Play();
        Invoke("LoadNextLevel", 2f);
        level = 1;
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(level);
    }
    void LoadLevelDead()
    {
        SceneManager.LoadScene(level);
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
        rigid_body.freezeRotation = false;
    }
    private void Thrust()
    {
        var thrust_speed = thrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {

            rigid_body.AddRelativeForce(Vector3.up*thrust_speed);
            if (!audio_source.isPlaying)
            {
                audio_source.PlayOneShot(audio_clip_thrust);
            }
            particle_thrust.Play();
        }
        else
        {
            audio_source.Stop();
            particle_thrust.Stop();
        }
    }
}
