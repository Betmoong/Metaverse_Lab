﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.Translate(-3, 0, 0); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { transform.Translate(3, 0, 0); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { transform.Translate(0, 3, 0); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { transform.Translate(0, -3, 0); }
    }
	public void UButtonDown()
	{
		transform.Translate(0, 3, 0);
	}
	public void DButtonDown()
	{
		transform.Translate(0, -3, 0);
	}
    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }

}
