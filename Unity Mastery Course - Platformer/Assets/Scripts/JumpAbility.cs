﻿using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb2D;
    private CharacterGrounding characterGrounding;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && characterGrounding.IsGrounded )
        {
            rb2D.AddForce(Vector2.up * jumpForce);
        }
    }
}