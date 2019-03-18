using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Jump Button Pressed");
            rb2D.AddForce(Vector2.up * jumpForce);
        }
    }
}