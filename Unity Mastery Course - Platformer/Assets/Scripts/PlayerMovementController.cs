using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private float horizontal;
    private float vertical;

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}