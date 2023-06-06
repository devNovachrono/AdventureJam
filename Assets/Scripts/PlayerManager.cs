using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Basic functions for only the player, inherits basic Entity functions from EntityManager

public class PlayerManager : EntityManager
{
    [System.Serializable] public struct Controls {
        public KeyCode interact;
    }

    public GameObject ConversationInstance;

    public void BeginConversation(string[] dialogue, Sprite sprite)
    {
        if (currentConversation != null) return;

        currentConversation = Instantiate(ConversationInstance).GetComponent<Conversation>();
        currentConversation.SetupConversation(dialogue, sprite);
    }

    internal void Interact()
    {
        if (interactor == null) return;

        IInteractable interactInterface = interactor.gameObject.GetComponent<IInteractable>();
        if (interactInterface == null) return;

        interactInterface.Interact();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Interactable")
        {
            interactor = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other == interactor)
        {
            interactor = null;
        }
    }

    private Collider2D interactor;
    internal Conversation currentConversation;
}
