using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    int Level;
    string CurrentScene;
    

	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        CurrentScene = scene.name;
        var charsToRemove = new string[] { "S", "c", "e", "n", "a" };
        foreach (var c in charsToRemove)
        {
            CurrentScene = CurrentScene.Replace(c, string.Empty);
        }
        Level = Int32.Parse(CurrentScene);
        Debug.Log(Level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Level++;
                SceneManager.LoadScene("Scena" + Level);
                break;
        }
    }
}
