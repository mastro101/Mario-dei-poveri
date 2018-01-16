using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : PowerUp {

    

	// Use this for initialization
	void Start () {
        MyTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        MyTransform.position += new Vector3(Speed, 0, 0);
	}

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (collision.gameObject.GetComponent<Player>().Life == 1)
                {
                    collision.gameObject.GetComponent<Player>().Life++;
                }
                Destroy(gameObject);
                break;
        }
    }
}
