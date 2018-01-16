using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            //Uccisione nemico saltandoli in testa
            case "Head":
                collision.gameObject.GetComponentInParent<Enemy>().Kill();
                GetComponentInParent<Player>().IsJumping = false;
                GetComponentInParent<Player>().Jump();
                break;
        }
    }
}
