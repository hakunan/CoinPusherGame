using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField,Header("UI�I�u�W�F�N�g")] TextMeshProUGUI currentCointext;
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
