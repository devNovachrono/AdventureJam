using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occlusion : MonoBehaviour
{
    private void Start() {
        player = GameObject.Find("Player").transform;
        playerManager = player.GetComponent<PlayerManager>();
    }

    private void Update() {
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 1);
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 1);
        }
    }

    private Transform player;
    private PlayerManager playerManager;
}
