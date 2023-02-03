using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouvenirPNJ_01 : MonoBehaviour
{
    public GameObject Souvenir;
    public PommeQuest pommeQuest;

    
    void SpawnSouvenirs()
    {
        Instantiate(Souvenir, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pommeQuest.pomme == true) 
        {
            SpawnSouvenirs();
            pommeQuest.pomme = false;   
  

        }

        

    }
}

