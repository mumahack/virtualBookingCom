﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationSelect : MonoBehaviour {

    private Component test;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClicked(string target)
    {
        Debug.Log("Ziel wurde ausgewählt!");
        SceneManager.LoadScene("FotosphereMono");
    }
}
