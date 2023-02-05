using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ShowDialogues : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI texte;
    public DialoguesSO dialoguesSO;
    public DialoguesSO dialoguesSO2;
    //private GlassesQuest glassesQuest;
    public bool glasses;
    public int dialogueLine;
    public float textSpeed;    


    private void Start()
    {
       //glassesQuest = GetComponent<GlassesQuest>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            dialogueBox.SetActive(true);
            texte.text = string.Empty;
            StartDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        if (glasses == false)
        {
            foreach (char c in dialoguesSO.dialogues[dialogueLine].ToCharArray())
            {
                texte.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        if (glasses == true)
        {
            foreach (char c in dialoguesSO2.dialogues[dialogueLine].ToCharArray())
            {
                texte.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

    }

    public void StartDialogue()
    {
        dialogueLine = 0;
        StartCoroutine(TypeLine());
    }


    public void NextLine()
    {
        if (glasses == false)
        {
            if (dialogueLine < dialoguesSO.dialogues.Length - 1)
            {
                dialogueLine++;
                texte.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                dialogueBox.SetActive(false);
            }
        }

        if (glasses == true)
        {
            if (dialogueLine < dialoguesSO2.dialogues.Length - 1)
            {
                dialogueLine++;
                texte.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                dialogueBox.SetActive(false);
            }
        }


    }


    public void SelectDialogueOnperformed(InputAction.CallbackContext obj)
    {
        if (glasses == false)
        {
            if (texte.text == dialoguesSO.dialogues[dialogueLine])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                texte.text = dialoguesSO.dialogues[dialogueLine];
            }
        }

        if (glasses == true)
        {
            if (texte.text == dialoguesSO2.dialogues[dialogueLine])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                texte.text = dialoguesSO2.dialogues[dialogueLine];
            }
        }

    }
}