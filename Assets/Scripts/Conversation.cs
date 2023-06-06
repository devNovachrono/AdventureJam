using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversation : MonoBehaviour
{
    public Image npcImage;
    public TextMeshProUGUI textBox;

    public void SetupConversation(string[] Dialogue, Sprite Image)
    {
        dialogue = Dialogue;
        textBox.text = Dialogue[0];
        npcImage.sprite = Image;
    }

    public bool ProceedDialogue()
    {
        currentDialogueOption += 1;
        if (currentDialogueOption >= dialogue.Length)
        {
            return false;
        }
        textBox.text = dialogue[currentDialogueOption];
        return true;
    }

    private int currentDialogueOption = 0;
    private string[] dialogue;
}
