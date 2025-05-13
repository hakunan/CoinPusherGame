using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFollow : MonoBehaviour
{
    /*
     * ベースが移動した際上のトリガーにのかっているコインをペアレントして追従させるための処理
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.transform.parent = null;
        }
    }
}
