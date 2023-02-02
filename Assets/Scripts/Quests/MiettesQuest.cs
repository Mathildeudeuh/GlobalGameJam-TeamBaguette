using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiettesQuest : MonoBehaviour
{


    private GameObject Wall_01;
    public bool miettes;
    private void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {

            Destroy(gameObject);
            Debug.Log("COLLISIONNED");

            Wall_01 = GameObject.FindGameObjectWithTag("ColliderQuest_1");
            DestroyObject(Wall_01);
            miettes = true;
  

        }

       

        /*if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("hit");
            
        }*/

    }
}

