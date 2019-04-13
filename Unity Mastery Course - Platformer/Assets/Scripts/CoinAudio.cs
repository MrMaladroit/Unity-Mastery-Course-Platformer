using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void OnDisable()
    {
        GameManager.instance.OnCoinsChanged -= HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coins)
    {
        audioSource.Play();
    }
}
