using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Script da inserire alla base del blocco

    //L'oggetto all'interno del blocco
    public GameObject Item;

    public Transform MyTransform;

    Vector3 SpawnItem;
	// Use this for initialization
	void Start () {

        //Se non ci sono oggetti all'interno mette una moneta in automatico
        if (Item == null)
        {
            Item = GameObject.Find("Coin");
        }

        //Per spawnare l'oggetto sopra il blocco
        MyTransform = GetComponent<Transform>();
        SpawnItem = MyTransform.position + new Vector3(0, 1.5f, 0);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Solo il player può interagire
        if (other.gameObject.tag == "Player")
        {
            //Se c'è una moneta la prende subito
            if (Item.name == "Coin")
            {
                Instantiate(Item, SpawnItem - new Vector3(0, 1.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Instantiate(Item, SpawnItem, new Quaternion(0, 0, 0, 0));                
            }
            //La base viene distrutta e il blocco funziona solo da platform (Cambio colore)
            Destroy(gameObject);
            GetComponentInParent<Renderer>().material.color = Color.gray;
        }
    }
}