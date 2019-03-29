using UnityEngine;
using TMPro;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI livesText;
    private void Start()
    {
        GameManager.instance.OnLivesChanged += HandleOnLivesChanged;
        livesText = GetComponent<TextMeshProUGUI>();
        livesText.SetText(GameManager.instance.Lives.ToString());
    }

    private void HandleOnLivesChanged(int lives)
    {
        livesText.SetText(lives.ToString());
    }
}