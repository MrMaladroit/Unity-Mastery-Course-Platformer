using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives; //{ get; private set; }

    public static GameManager instance;

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
        SceneManager.LoadScene(0);
    }
}