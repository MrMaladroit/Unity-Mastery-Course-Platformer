using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI coinsText;
    private void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        GameManager.instance.OnCoinsChanged += HandleOnCoinsChanged;
        coinsText.SetText(GameManager.instance.Coins.ToString());
    }

    private void HandleOnCoinsChanged(int coins)
    {
        coinsText.SetText(coins.ToString());
    }
}