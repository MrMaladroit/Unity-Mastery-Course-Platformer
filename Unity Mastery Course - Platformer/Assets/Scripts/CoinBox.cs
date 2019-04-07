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

        if(collision.WasHitByPlayer() && 
            collision.WasHitFromBottom() &&
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

    
}