using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5.0f;
    public Vector3 Startposition;
    public bool running=false;
	// Use this for initialization
	void Start ()
    {
        
	}
	public void ResetPosition()
    {
        transform.localPosition = Startposition;
    }
    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
