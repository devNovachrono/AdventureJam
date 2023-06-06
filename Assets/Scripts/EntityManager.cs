using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manager for controlling basic Entity Actions

public class EntityManager : MonoBehaviour
{
    public float MoveSpeed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    internal virtual void Movement(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    internal Rigidbody2D rb;
}
