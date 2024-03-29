using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static int coinCount = 0;
    public TMP_Text coinCountText;

    void Start()
    {
        UpdateCoinDisplay();
    }

    // This method is now public and static to allow external calls
    public void IncrementCoinCount()
    {
        coinCount++;
        UpdateCoinDisplay();
        // Note: Since we're in a static context, directly updating the UI here might not be straightforward
    }

    void UpdateCoinDisplay()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coinz: " + coinCount.ToString();
        }
    }

}