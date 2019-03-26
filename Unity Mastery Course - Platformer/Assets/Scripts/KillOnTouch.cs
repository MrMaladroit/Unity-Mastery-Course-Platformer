using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovementController playerMovementController = collision.collider.GetComponentInChildren<PlayerMovementController>();
        if(playerMovementController != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}