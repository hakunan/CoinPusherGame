using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestoryArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
