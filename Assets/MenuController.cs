﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Start!"))
        {
            SceneManager.LoadScene("GameScene");
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Quit"))
        {
            Application.Quit();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
