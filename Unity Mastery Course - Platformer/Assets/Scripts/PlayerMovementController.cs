using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
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
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}