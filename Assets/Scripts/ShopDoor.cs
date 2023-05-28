using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopDoor : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Shop");
    }
}
