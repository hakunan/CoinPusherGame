using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField,Header("UIオブジェクト")] TextMeshProUGUI currentCointext;
    [SerializeField] GameObject gameoverScreen;

    public void SetCurrentCoin(int coin)
    {
        currentCointext.text = "Coin: "+ coin.ToString();
    }
    public void GameOverUIActive()
    {
        gameoverScreen.SetActive(true);
    }
    
}
