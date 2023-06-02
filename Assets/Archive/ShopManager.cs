using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.SceneManagement;

//Just as confusing as the OpenAI scripts, dont even try LOL. Again, I'm doing my best to
//make it better to read


//This is the actual script. Anything above this line is just a placeholder for testing
/* public class ShopManager : MonoBehaviour, IConversation
{
    public TMP_InputField playerBox;
    public TextMeshProUGUI npcBox;

    public Button sendButton;
    public Button denyButton;
    public Button acceptButton;
    public Button continueButton;

    private AI ai;

    private void Start() {
        ai = gameObject.AddComponent<AI>() as AI;
        ai.aiBox = npcBox;
        Initiate();
    }

    public void SendMessage()
    {
        ai.Send(playerBox.text);
        playerBox.text = "";
        npcBox.text = "...";
        SetHaggleButtons(false);
        sendButton.interactable = false;
        playerBox.interactable = false;
    }

    public void Response(string message)
    {
        npcBox.text = message;
        SetHaggleButtons(true);
        playerBox.interactable = true;
    }

    internal void Initiate()
    {
        ai.Initiate();
    }

    internal void PrepareForNextCustomer()
    {
        playerBox.interactable = false;
        sendButton.interactable = false;
        SetHaggleButtons(false);
        continueButton.interactable = true;
    }

    public void ToggleSending()
    {
        if (playerBox.text.Length < 4)
        {
            sendButton.interactable = false;
        } else {
            sendButton.interactable = true;
        }
    }

    public void SetHaggleButtons(bool debounce)
    {
        denyButton.interactable = debounce;
        acceptButton.interactable = debounce;
    }

    public void Accept()
    {
        JArray conversation = ai.GetConversation();
        string lastResponse = conversation.Last.Value<string>("content");
        string[] splitResponse = lastResponse.Split(" ");
        System.Array.Reverse(splitResponse);

        foreach (var word in splitResponse)
        {
            int result;
            if (int.TryParse(word, out result))
            {
                Debug.Log($"Bought for {word} gold!");
                PrepareForNextCustomer();
                npcBox.text = "";
                break;
            }
        }
    }

    public void Deny()
    {
        Debug.Log("You denied the customer's item.");
        npcBox.text = "";
        PrepareForNextCustomer();
    }

    public void Continue()
    {
        continueButton.interactable = false;
        npcBox.text = "...";
        Debug.Log("Loading next customer...");
        Initiate();
    }

    public void LeaveShop()
    {
        SceneManager.LoadScene("Town");
    }
} */