using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls all player input detection. If you want to change something about the player
//directly (like velocity), consider changing the EntityManager or PlayerManager

public class PlayerInput : MonoBehaviour
{

    public PlayerManager.Controls controls;

    private void Start() {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update() {
        horizontalMomentum = Input.GetAxisRaw("Horizontal");
        verticalMomentum = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(controls.interact))
        {
            playerManager.Interact();
        }
    }

    private void FixedUpdate() {
        Vector3 movementForce = new Vector3(horizontalMomentum, verticalMomentum, 0) * playerManager.MoveSpeed;
        playerManager.Movement(movementForce);
    }

    private PlayerManager playerManager;
    private float horizontalMomentum;
    private float verticalMomentum;
}
