using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI texte;
    public DialoguesSO dialoguesSO;
    public int dialogueLine;
    public float textSpeed;


    void Start()
    {
        StartForgotten();
    }

    public void StartForgotten()
    {
        dialogueLine = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
            foreach (char c in dialoguesSO.dialogues[dialogueLine].ToCharArray())
            {
                texte.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

    }
}
