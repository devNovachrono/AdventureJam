using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using TMPro;

public class AI : MonoBehaviour
{
    public JArray currentConversation = new JArray();

    internal TextMeshProUGUI aiBox;

    public void Send(string message)
    {
        JObject msg = new JObject();
        msg.Add(new JProperty("role", "user"));
        msg.Add(new JProperty("content", message));
        currentConversation.Add(msg);
        StartCoroutine(RetrieveResponse(currentConversation));
    }

    public void Initiate()
    {
        currentConversation = new JArray();
        StartCoroutine(BeginDialogue());
    }

    public JArray GetConversation()
    {
        return currentConversation;
    }

    private void Respond(string msg)
    {
        IConversation isConversation = GetComponent<IConversation>();
        if (isConversation != null)
        {
            isConversation.Response(msg);
        }
    }

    public IEnumerator BeginDialogue()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://haggle.deno.dev/initiate?npcAction=Selling");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string results = www.downloadHandler.text;

            JArray intro = JArray.Parse(results);

            currentConversation = intro;

            Respond(currentConversation.Last.Value<string>("content"));
        }
    }

    public IEnumerator RetrieveResponse(JArray conversation)
    {
        string data = conversation.ToString();

        UnityWebRequest www = UnityWebRequest.Get($"https://haggle.deno.dev/conversation?conversation={data}");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string results = www.downloadHandler.text;

            JObject msg = new JObject();
            msg.Add(new JProperty("role", "assistant"));
            msg.Add(new JProperty("content", results));
            currentConversation.Add(msg);
            Respond(results);
        }

        www.Dispose();
    }
}
