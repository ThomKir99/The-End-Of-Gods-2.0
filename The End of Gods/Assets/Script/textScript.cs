﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (InteractAction.textstatus == "off")
        {
            Destroy(gameObject);
        }
	}
}