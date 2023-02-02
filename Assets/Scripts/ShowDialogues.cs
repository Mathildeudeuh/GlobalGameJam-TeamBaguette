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
    public int dialogueLine;
    public float textSpeed;
    

    //public bool isSpeaking;
    //private bool wantToTalk = false;


    private void Start()
    {
        texte.text = string.Empty;
        StartDialogue();
        //isSpeaking = false;
    }

    private void Update()
    {
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialoguesSO.dialogues[dialogueLine].ToCharArray())
        {
            texte.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void StartDialogue()
    {
        dialogueLine = 0;
        StartCoroutine(TypeLine());
        //texte.text = dialoguesSO.dialogues[dialogueLine].ToString();
    }


    public void NextLine()
    {
        if (dialogueLine < dialoguesSO.dialogues.Length - 1)
        {
            dialogueLine++;
            texte.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            //dialogueBox.SetActive(false);
        }

        /*if (isSpeaking == true && dialogueLine != dialoguesSO.dialogues.Length - 1)
        {
            dialogueLine++;
            texte.text = dialoguesSO.dialogues[dialogueLine].ToString();
        }

        else if (isSpeaking == true && dialogueLine == dialoguesSO.dialogues.Length -1)
        {
            isSpeaking = false;
        }*/
    }


    public void SelectDialogueOnperformed(InputAction.CallbackContext obj)
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
}