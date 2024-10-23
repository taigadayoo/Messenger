using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtanScripts : MonoBehaviour
{
    PlayerMove playerMove;
    AnswerJudge answerJudge;
    ButtanTextManager textManager;
    [SerializeField]
    ResultManager resultManager;
    [SerializeField]
    ScoreDisplay scoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
        answerJudge = FindObjectOfType<AnswerJudge>();
        playerMove = FindObjectOfType<PlayerMove>();
        textManager = FindObjectOfType<ButtanTextManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   public void OnClick(GameObject clickedButton)
    {
        playerMove.stopAssign = false;
       if(answerJudge.humanClear && clickedButton.tag == "Answer")
        {
            if (answerJudge.messegeClear)
            {
                SceneManager.LoadScene("Stage1");
                GameManager.playerSpeed += 2;
            }
            GameManager.clearHuman += 1;//�X�R�A�����Z
            resultManager.UpdateScoreText();//�X�R�A�̃e�L�X�g���X�V
            scoreDisplay.UpdateScoreText();
            answerJudge.messegeClear = true; //��ڂ̏ꍇ�Е��̃N���A����
            playerMove.answerPanel.SetActive(false);
            SampleSoundManager.Instance.PlaySe(SeType.SE3);
            playerMove.okDush = false; //�v���C���[���~�߂�
            RandomTagAssigner.usedTags.Clear();//�^�O�̎g�p�󋵂����Z�b�g
            textManager.clearText = false; 
        }
       else if (answerJudge.humanClear2 && clickedButton.tag == "Answer2")
        {
            if(answerJudge.messegeClear)
            {
                SceneManager.LoadScene("Stage1");
                GameManager.playerSpeed += 2;
            }
            GameManager.clearHuman += 1;
            SampleSoundManager.Instance.PlaySe(SeType.SE3);
            resultManager.UpdateScoreText();//��Ɠ��l
            scoreDisplay.UpdateScoreText();
            RandomTagAssigner.usedTags.Clear();
            answerJudge.messegeClear = true;
            playerMove.okDush = false;
            playerMove.answerPanel.SetActive(false);
            textManager.clearText = false;
        }
        else if (answerJudge.humanClear && clickedButton.tag != "Answer")
        {
            playerMove.okDush = true;
            resultManager.OnGameOver();
        }
        else if (answerJudge.humanClear2 && clickedButton.tag != "Answer2" )
        {
            playerMove.okDush = true;
            resultManager.OnGameOver();
        }
        else if(!answerJudge.humanClear )
        {
            playerMove.okDush = true;
            resultManager.OnGameOver();
        }

    }
}
