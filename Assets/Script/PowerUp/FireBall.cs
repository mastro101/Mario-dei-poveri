using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    Enemy enemy;
    public Rigidbody rb;

    public float force;
    public float lifeTime;
    public float timeInGame;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	

	void Update () {        
        // Autodistruzione
        if (timeInGame <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            // Prende la classe Enemy dell'Enemy colpito
            enemy = collision.gameObject.GetComponent<Enemy>();
            // Danno al nemico
            enemy.Damage(1);
            // Autodistruzione
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(new Vector3(force, 0, 0));
    }
}
