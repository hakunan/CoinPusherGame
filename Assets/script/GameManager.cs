using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const float BaseMoveLength = 1.5f; //�x�[�X�������͈�


    [SerializeField] UiManager uiManager;
    [SerializeField] GameObject baseObject;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject coinSpawnObject;
    [SerializeField] GameObject starterObject;

    [Header("�ݒ�")]
    [SerializeField] float baseSpeed = 2;�@//�x�[�X�̑��x
    [SerializeField] int firstCoinSpawn = 20; //�����̏o������
    [SerializeField] float moveSpeed = 0.3f; //�X�^�[�^�[���������x

    private int _coin =10 ;

    private void Start()
    {
        uiManager.SetCurrentCoin(_coin);
        FirstSpawnCoin();
    }
    private void Update()
    {
        //�L�[����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotCoin();
        }
        //�x�[�X�̈ړ�����
        var z = Mathf.PingPong(Time.time/baseSpeed, BaseMoveLength);

        baseObject.transform.localPosition = new Vector3(0, 0, z);
    }
    private void FixedUpdate()
    {
        //Horizontal�L�[����
        var valox = moveSpeed * Input.GetAxisRaw("Horizontal");
        starterObject.transform.position = starterObject.transform.position + new Vector3(valox, 0f, 0f);
    }

    private void ShotCoin()
    {
        if(_coin > 0)
        {
            Instantiate(coinPrefab, starterObject.transform.position, Quaternion.Euler(0,0,90));

            _coin--;
            uiManager.SetCurrentCoin(_coin);
        }
        else
        {
            uiManager.GameOverUI();
        }
    }
    private void FirstSpawnCoin()
    {
        for(int i = 1; i <= firstCoinSpawn; i++)
        {
        �@�@//�R�C���X�|�[���I�u�W�F�N�g�̃T�C�Y�ɉ����ăR�C���𐶐�

            Vector3 randomPoint = coinSpawnObject.transform.position + new Vector3(
                Random.Range(-coinSpawnObject.transform.localScale.x/2, coinSpawnObject.transform.localScale.x/2),
                coinSpawnObject.transform.position.y,
                Random.Range(-coinSpawnObject.transform.localScale.z / 2, coinSpawnObject.transform.localScale.z / 2));

            Instantiate(coinPrefab, randomPoint, Quaternion.identity);
        }
    }
    public void GetCoin()
    {
        _coin++;
        uiManager.SetCurrentCoin(_coin);
    }
}
