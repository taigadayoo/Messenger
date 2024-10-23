using UnityEngine.UI;
using UnityEngine;


public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Textコンポーネントをアタッチ
    private int playerScore = 0; // 例: スコア

    void Start()
    {
        UpdateScoreText(); // 初期スコアを表示
        playerScore = GameManager.clearHuman;
    }

    void Update()
    {
     
    }

  public  void UpdateScoreText()
    {
        scoreText.text = "伝えた人数: " +GameManager.clearHuman.ToString();
    }
}