using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All interfaces go here

public interface IInteractable {
    void Interact();
}

public interface IConversation {
    void Response(string message);
}