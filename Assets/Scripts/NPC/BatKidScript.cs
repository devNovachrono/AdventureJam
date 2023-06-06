using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatKidScript : EntityManager, IInteractable
{
    public string[] Dialogue;
    public Sprite Sprite;

    private void Start() {
        player = GameObject.Find("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    public void Interact()
    {
        playerManager.BeginConversation(Dialogue, Sprite);
    }
    private GameObject player;
    private PlayerManager playerManager;
}
