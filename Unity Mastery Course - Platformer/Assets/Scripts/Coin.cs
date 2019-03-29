using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if(player != null)
        {
            GameManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}