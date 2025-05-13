using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFollow : MonoBehaviour
{
    /*
     * �x�[�X���ړ������ۏ�̃g���K�[�ɂ̂����Ă���R�C�����y�A�����g���ĒǏ]�����邽�߂̏���
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
