using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDialogues : MonoBehaviour
{
    public DialoguesSO dialoguesSO;
    public bool isSpeaking;
    public TextMeshProUGUI texte;
    public int dialogueLine;


    private void Start()
    {
        isSpeaking = false;
    }


    public void StartDialogue()
    {
        texte.text = dialoguesSO.dialogues[dialogueLine].ToString();
    }

    public void NextLine()
    {
        if (isSpeaking == true && dialogueLine != dialoguesSO.dialogues.Length - 1)
        {
            dialogueLine++;
            texte.text = dialoguesSO.dialogues[dialogueLine].ToString();
        }

        else if (isSpeaking == true && dialogueLine == dialoguesSO.dialogues.Length -1)
        {
            isSpeaking = false;
        }
    }
}