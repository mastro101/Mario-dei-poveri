using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlower : PowerUp {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            player.isFlower = true;
            player.Life = 3;
            Destroy(gameObject);
        }
    }
}
