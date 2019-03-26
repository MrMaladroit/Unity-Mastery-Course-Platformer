﻿using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float Speed { get; private set; }

    [SerializeField] private float moveSpeed = 3f;
    private float horizontal;
    private float vertical;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0);
        Speed = Mathf.Abs(horizontal);
        if (horizontal != 0)
        {
            spriteRenderer.flipX = horizontal > 0;
        }

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}