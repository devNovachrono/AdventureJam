using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic functions for only the player, inherits basic Entity functions from EntityManager

public class PlayerManager : EntityManager
{
    [System.Serializable] public struct Controls {
        public KeyCode interact;
    }

    internal void Interact()
    {
        if (interactor == null) return;

        IInteractable interactInterface = interactor.gameObject.GetComponent<IInteractable>();
        if (interactInterface != null)
        {
            interactInterface.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Interactable")
        {
            interactor = other;
        } else if (other.tag == "Candy")
        {
            GlobalData.AddCandy(1);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other == interactor)
        {
            interactor = null;
        }
    }

    private Collider2D interactor;
}
