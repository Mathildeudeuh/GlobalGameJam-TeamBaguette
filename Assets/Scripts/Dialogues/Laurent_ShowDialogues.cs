using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Laurent_ShowDialogues : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI texte;
    public DialoguesSO dialoguesSO;
    public DialoguesSO dialoguesSO2;
    public int dialogueLine;
    public float textSpeed;
    public bool miettes;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            dialogueBox.SetActive(true);
            texte.text = string.Empty;
            StartDialogue();
        }
    }


    private void Start()
    {
    }

    private void Update()
    {
    }

    IEnumerator TypeLine()
    {
        if (miettes == false)
        {
            foreach (char c in dialoguesSO.dialogues[dialogueLine].ToCharArray())
            {
                texte.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        if (miettes == true)
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
        if (miettes == false)
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

        if (miettes == true)
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
        if (miettes == false)
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

        if (miettes == true)
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
