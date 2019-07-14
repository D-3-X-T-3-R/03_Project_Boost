using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occilator : MonoBehaviour {
    public Vector3 movement_vector= new Vector3(10,0,0);
    [Range(0, 1)] public float move_by_value;
    public float ossilation_period = 2f;

    Vector3 start_position;
    // Use this for initialization
    void Start () {
        start_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (ossilation_period <= Mathf.Epsilon) { return; }
        const float tau = Mathf.PI * 2;
        float cycle = Time.time / ossilation_period;
        move_by_value = Mathf.Sin(cycle * tau)/2 +0.5f;
        Vector3 offset = movement_vector * move_by_value;
        transform.position = start_position + offset;
        print("move");
	}
}
