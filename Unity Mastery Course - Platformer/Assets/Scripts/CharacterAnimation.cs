using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private IMove mover;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        mover = GetComponentInChildren<IMove>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (mover.Speed != 0)
        {
            spriteRenderer.flipX = mover.Speed > 0;
        }

        float speed = mover.Speed;    
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }
}