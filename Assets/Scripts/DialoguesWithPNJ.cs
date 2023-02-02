using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialoguesWithPNJ : MonoBehaviour
{
    /*public bool isPNJ;
    public bool wantToTalk;
    [SerializeField] private GameObject conversationBox;

    void Start()
    {
        isPNJ = false;
        wantToTalk = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PNJ"))
        {
            isPNJ = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPNJ = false;
    }

    public void SelectDialogueOnperformed(InputAction.CallbackContext obj)
    {
        wantToTalk = true;
    }


    void Update()
    {
        if (isPNJ == true && wantToTalk == true)
        {
            conversationBox.SetActive(true);

            if (GetComponent<ShowDialogues>().isSpeaking == true)
            {
                GetComponent<ShowDialogues>().NextLine();
            }

            else if (GetComponent<ShowDialogues>().isSpeaking == false)
            {
                GetComponent<ShowDialogues>().StartDialogue();
            }
        }
    }*/
}
