using UnityEngine.UI;
using UnityEngine;


public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Text�R���|�[�l���g���A�^�b�`
    private int playerScore = 0; // ��: �X�R�A

    void Start()
    {
        UpdateScoreText(); // �����X�R�A��\��
        playerScore = GameManager.clearHuman;
    }

    void Update()
    {
     
    }

  public  void UpdateScoreText()
    {
        scoreText.text = "�`�����l��: " +GameManager.clearHuman.ToString();
    }
}