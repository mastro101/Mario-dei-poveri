using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isFirstManager;

	void Awake () {
        
        DontDestroyOnLoad(transform.gameObject);
        GameManager[] gm = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].isFirstManager == true)
            {
                return;
            }
        }
        isFirstManager = true;
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].isFirstManager == false)
            {
                Destroy(gm[i].gameObject);
            }
        }
        
	}
}
