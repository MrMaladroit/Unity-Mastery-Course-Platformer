using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if(player != null)
        {
            GameManager.instance.HandleCollectible(gameObject);
            Destroy(gameObject);
        }
    }
}