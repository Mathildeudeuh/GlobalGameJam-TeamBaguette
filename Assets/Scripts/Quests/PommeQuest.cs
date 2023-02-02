using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PommeQuest : MonoBehaviour
{

    public bool pomme;


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {
            Destroy(gameObject);
            Debug.Log("COLLISIONNED");

            pomme = true;

        }


        /*if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("hit");
            
        }*/

    }



}

