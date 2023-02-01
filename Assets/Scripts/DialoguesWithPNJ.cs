using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesWithPNJ : MonoBehaviour
{
    public bool isPNJ;
    public Transform checkPNJ;
    public LayerMask whatIsPNJ;
    [SerializeField] private GameObject conversationBox;

    void Start()
    {
        
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


    void Update()
    {
        if (isPNJ == true && Input.GetKeyDown(KeyCode.S) == true) //public void JumpOnperformed(InputAction.CallbackContext obj) -> booléen = true
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
    }
}
