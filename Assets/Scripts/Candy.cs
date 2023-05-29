using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public float detectorRadius;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        if (player == null)
        {
            player = FindPlayer();
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementMomentum);
        movementMomentum += .01f;

    }

    private GameObject FindPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectorRadius);

        for (var i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Player")
            {
                animator.enabled = false;
                return hitColliders[i].gameObject;
            }
        }
        return null;
    }

    private GameObject player;
    private Animator animator;

    private float movementMomentum;
}
