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

            Lives = 3;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void KillPlayer()
    {
        Lives--;
        if(OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }
        SceneManager.LoadScene(0);
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