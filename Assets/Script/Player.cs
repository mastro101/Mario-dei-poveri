using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {
    
    static int PlayerCount;

    public int CurrentCoin;

    Vector3 Checkpoint;
    

	void Start () {

        // N° Giocatori in campo
        PlayerCount++;
        Debug.Log("N° Player: " + PlayerCount);

        // Aggiungi componente
            // transform
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

        //Start point
        Checkpoint = MyTransform.position;
        
	}
	
	void Update () {

		if (Name == "Mario")
        {
            // Movimento Sinistra-Destra
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MyTransform.position = MyTransform.position + new Vector3(-Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MyTransform.position = MyTransform.position + new Vector3(Speed, 0, 0);
            }

            // Salto
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                Jump();
            }

            // Corsa
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Speed += RunSpeed;
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                Speed -= RunSpeed;
            }
        }

        if (Name == "Luigi")
        {
            if (Input.GetKey(KeyCode.A))
            {
                MyTransform.position = MyTransform.position + new Vector3(-Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                MyTransform.position = MyTransform.position + new Vector3(Speed, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.W) && IsJumping == false)
            {
                rb.AddForce(Vector3.up * JumpForce);
                IsJumping = true;
                Debug.Log(IsJumping);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Speed = Speed + RunSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                Speed = Speed - RunSpeed;
            }
        }

        //Respawn
        if (IsAlive == false)
        {
            MyTransform.position = Checkpoint;
            MyCollider.enabled = false;
            MyRender.enabled = false;
            StartCoroutine(RespawnTime(2));
            Life = 2;
        }
        else
        {
            MyCollider.enabled = true;
            MyRender.enabled = true;
        }

	}

    //Tempo per il Respawn
    IEnumerator RespawnTime(int S)
    {
        yield return new WaitForSeconds(S);
        IsAlive = true;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Checkpoint":
                Checkpoint = other.transform.position;
                break;
        }
    }
}
