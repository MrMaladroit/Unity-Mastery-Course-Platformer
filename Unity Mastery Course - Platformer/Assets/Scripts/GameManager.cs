﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource deathAudioSource;

    public int Lives { get; private set; }
    public int Coins { get; private set; }
    public int TotalCoinsForLifeUp = 10;

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
        deathAudioSource.Play();
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

    public void HandleCollectible(GameObject gameObject)
    {
        if (gameObject.tag == "Life Up")
        {
            AddExtraLife();
        }
        else if (gameObject.tag == "Coin")
        {
            AddCoin();
        }
    }

    public void AddExtraLife()
    {
        Lives++;

        if(OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }
    }

    public void AddCoin()
    {
        Coins++;

        if(Coins >= TotalCoinsForLifeUp)
        {
            AddExtraLife();
            Coins = 0;
        }

        if(OnCoinsChanged != null)
        {
            OnCoinsChanged(Coins);
        }
    }
}