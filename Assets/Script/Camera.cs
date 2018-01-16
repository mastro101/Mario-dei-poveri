using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform Mario;
    public Transform Luigi;
    private Transform MyTransform;

	// Use this for initialization
	void Start () {
        MyTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Luigi == null)
        {
            MyTransform.position = Mario.position + new Vector3(0, 0, -10);
        }
        else
        {
            Vector3 from = Mario.position;
            Vector3 to = Luigi.position;
            MyTransform.position = Vector3.Lerp(from, to, 0.50f) + new Vector3(0, 0, -10);
        }
	}
}
