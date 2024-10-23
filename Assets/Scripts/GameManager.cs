using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // staticな変数。すべてのシーンで共有される
    public static int clearHuman = 0;　//スコア
    public static int playerSpeed = 5;//playerの速度
    public static bool isFirstStart = false;
    void Awake()
    {
        // 既にインスタンスが存在する場合は、重複しないようにこのオブジェクトを破棄する
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // インスタンスがまだ存在しない場合、このオブジェクトをシングルトンとして設定し、破棄されないようにする
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // staticな関数
    private void Start()
    {
      
    }
    private void Update()
    {
     
       
    }
    // 非staticな関数
    public void ResetGame()
    {
        clearHuman = 0;
        playerSpeed = 5;
    }
}