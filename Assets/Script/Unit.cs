using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Transform MyTransform = null;
    public Rigidbody rb = null;
    public Collider MyCollider;
    public MeshRenderer MyRender;

    public string Name;
    public int Life;
    public bool IsAlive;
    public float Speed;
    public float RunSpeed;
    public float JumpForce;
    public bool IsJumping = false;


    public void Damage(int Point)
    {
        Life -= Point;
        if (Life <= 0)
        {
            IsAlive = false;
        }
    }

    public void Kill()
    {
        Damage(Life);
    }

    public void Jump()
    {
        if (IsJumping == false)
        {
            rb.AddForce(Vector3.up * JumpForce);
            IsJumping = true;
            Debug.Log(gameObject.tag + IsJumping);
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            //Per Non Fare il doppio salto
            case "Platform":
                IsJumping = false;
                break;
            //Morte da caduta o lava etc.
            case "Respawn":
                Kill();
                break;
        }
    }
}
