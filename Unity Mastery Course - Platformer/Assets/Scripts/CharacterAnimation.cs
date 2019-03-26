using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementController playerMovementController;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerMovementController = GetComponentInChildren<PlayerMovementController>();

    }

    private void Update()
    {
        float speed = playerMovementController.Speed;    
        animator.SetFloat("Speed", speed);
    }
}