using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator PlayerAnimator;
    private PlayerManager PlayerManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerManager = transform.parent.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (PlayerManager.currentConversation != null)
        {
            horizontal = 0;
            vertical = 0;
        }

        PlayerAnimator.SetFloat("horizontal", horizontal);
        PlayerAnimator.SetFloat("vertical", vertical);
    }
}
