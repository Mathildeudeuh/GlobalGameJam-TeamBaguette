using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDialogues : MonoBehaviour
{
    public DialoguesSO dialoguesSO;
    public bool isSpeaking;
    public TextMeshProUGUI texte;
    public float textSpeed;
    public int dialogueLine;
    public GameObject dialogueBox;
    


    private void Start()
    {
        texte.text = string.Empty;
        StartDialogue();
        //isSpeaking = false;
    }


    public void StartDialogue()
    {
        dialogueLine = 0;
        StartCoroutine(TypeLine());
        //texte.text = dialoguesSO.dialogues[dialogueLine].ToString();
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialoguesSO.dialogues[dialogueLine].ToCharArray())
        {
            texte.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {     
        if (dialogueLine < dialoguesSO.dialogues.Length - 1)
        {
            dialogueLine++;
            dialogueLine = 0;
            StartCoroutine(TypeLine());
        }

        else
        {
            dialogueBox.SetActive(false);
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
}