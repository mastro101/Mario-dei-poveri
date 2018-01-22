using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour {

    public GameObject FireBall;
    Player player;

    
    void Start () {
        player = GetComponentInParent<Player>();
	}

    
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightShift) && player.isFlower)
        {
            FireBall ball = Instantiate(FireBall, gameObject.transform.position, gameObject.transform.rotation).GetComponent<FireBall>();
            ball.timeInGame = Time.time + ball.lifeTime;
            ball.Shoot();
            ball.rb.useGravity = true;
        }
	}
}
