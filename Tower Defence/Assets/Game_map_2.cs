using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour {
    public GameObject blackhole;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BlackHole();
	}

    void BlackHole()
    {
       blackhole.transform.Rotate(Vector3.up, 1f);
    }
}
