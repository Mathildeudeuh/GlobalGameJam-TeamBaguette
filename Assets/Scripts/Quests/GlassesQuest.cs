using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesQuest : MonoBehaviour
{

    public bool glasses;

    private void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {

            Destroy(gameObject);
            Debug.Log("COLLISIONNED");

            glasses = true;
  

        }

       

        /*if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("hit");
            
        }*/

    }
}

