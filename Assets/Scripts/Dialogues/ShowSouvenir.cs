using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowSouvenir : MonoBehaviour
{
    public GameObject souvenirScreen;
    public TextMeshProUGUI texte;
    public string souvenir;
    public float textSpeed;
    public GameObject souvenirCollider;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            souvenirScreen.SetActive(true);
            texte.text = string.Empty;
            StartSouvenir();
            var col = souvenirCollider.GetComponent<Collider2D>();
            col.enabled = !col.enabled;
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in souvenir.ToCharArray())
        {
            texte.text += c;
            yield return new WaitForSeconds(textSpeed);
        }


        foreach (char c in souvenir.ToCharArray())
        {
            texte.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void StartSouvenir()
    {
        StartCoroutine(TypeLine());
    }
}
