using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {

    static int EnemyCount;

    public float LeftLimit;
    public float RightLimit;

    bool GoLeft = true;
    bool GoRight = false;

	void Start () {

        //Conto dei nemici
        EnemyCount++;
        Debug.Log("N° Enemy: " + EnemyCount);

        //Componenti
            // Transform
		MyTransform = GetComponent<Transform>();
        if (MyTransform == null)
        {
            MyTransform = gameObject.AddComponent<Transform>();
        }
            // rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;
            // Collider
        MyCollider = GetComponent<Collider>();
            // Render
        MyRender = GetComponent<MeshRenderer>();
    }

	void FixedUpdate () {
        if (GoLeft == true)
        {
            GoRight = false;
            MyTransform.position = MyTransform.position + new Vector3(-Speed, 0, 0);
            if (MyTransform.position.x < LeftLimit)
            {
                GoRight = true;
            }
        }

        if (GoRight == true)
        {
            GoLeft = false;
            MyTransform.position = MyTransform.position + new Vector3(+Speed, 0, 0);
            if (MyTransform.position.x > RightLimit)
            {
                GoLeft = true;
            }
        }
    }

    private void Update()
    {
        if (IsAlive == false)
        {
            Destroy(gameObject);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        //Danno al giocatore
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<Player>().Damage(1);
                break;
        }
    }
}