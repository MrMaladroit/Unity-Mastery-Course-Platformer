using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }
    public int Coins { get; private set; }

    public static GameManager instance;

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        Lives = 3;
    }

    public void KillPlayer()
    {
        Lives--;
        if(OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if(Lives <= 0)
        {
            SceneManager.LoadScene(0);
            Lives = 3;
            if (OnLivesChanged != null)
            {
                OnLivesChanged(Lives);
            }
            Coins = 0;
            if(OnCoinsChanged != null)
            {
                OnCoinsChanged(Coins);
            }
        }
        else
        {
            SendPlayerToCheckpoint();
        }
    }

    private void SendPlayerToCheckpoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        Checkpoint checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();
        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }

    public void AddCoin()
    {
        Coins++;
        if(OnCoinsChanged != null)
        {
            OnCoinsChanged(Coins);
        }
    }
}