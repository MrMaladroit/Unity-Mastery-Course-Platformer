using System;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer enabledSprite;
    [SerializeField]
    private SpriteRenderer disabledSprite;
    [SerializeField]
    private int totalCoins;

    private int remainingCoins;
    private Animator animator;

    private void Awake()
    {
        remainingCoins = totalCoins;
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponentInChildren<PlayerMovementController>();

        if(player != null && 
            WasHitFromBottom(collision) &&
            remainingCoins > 0)
        {
            GameManager.instance.AddCoin();
            remainingCoins--;
            animator.SetTrigger("Flip");

            if(remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;
            }
        }
    }

    private bool WasHitFromBottom(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}