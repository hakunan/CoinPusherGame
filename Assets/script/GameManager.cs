using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const float BaseMoveLength = 1.5f; //ベースが動く範囲


    [SerializeField] UiManager uiManager;
    [SerializeField] GameObject baseObject;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject coinSpawnObject;
    [SerializeField] GameObject starterObject;

    [Header("設定")]
    [SerializeField] float baseSpeed = 2;　//ベースの速度
    [SerializeField] int firstCoinSpawn = 20; //初期の出現枚数
    [SerializeField] float moveSpeed = 0.3f; //スターターが動く速度

    private int _coin =10 ;

    private void Start()
    {
        uiManager.SetCurrentCoin(_coin);
        FirstSpawnCoin();
    }
    private void Update()
    {
        //キー入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotCoin();
        }
        //ベースの移動処理
        var z = Mathf.PingPong(Time.time/baseSpeed, BaseMoveLength);

        baseObject.transform.localPosition = new Vector3(0, 0, z);
    }
    private void FixedUpdate()
    {
        //Horizontalキー入力
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
        　　//コインスポーンオブジェクトのサイズに沿ってコインを生成

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
