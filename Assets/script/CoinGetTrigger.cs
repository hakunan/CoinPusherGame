using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGetTrigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameManager.GetCoin();
        }
    }
}
