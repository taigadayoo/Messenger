using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    public Text scoreText; // Text�R���|�[�l���g���A�^�b�`

    public RectTransform rectTransform; // �ړ�������RectTransform
    public Vector2 targetPosition;      // �ړ���̍��W
    public float duration = 1.0f;       // �ړ��ɂ����鎞��
    // Start is called before the first frame update
    void Start()
    {

        UpdateScoreText();
    }

    void Update()
    {

    }

  public  void UpdateScoreText()
    {
        scoreText.text =  GameManager.clearHuman.ToString();
    }

  public void OnGame()
    {
        GameManager.isFirstStart = false;
        GameManager.playerSpeed = 5;
        GameManager.clearHuman = 0;
        SampleSoundManager.Instance.StopBgm();
        SampleSoundManager.Instance.PlayBgm(BgmType.BGM2);
        SceneManagement.sceneInstance.OnGame();
    }
    public void OnTitle()
    {
        GameManager.isFirstStart = false;
        GameManager.playerSpeed = 5;
        GameManager.clearHuman = 0;
        RandomTagAssigner.usedTags.Clear();
        SceneManagement.sceneInstance.OnTitle();

    }
    public void OnGameOver()
    {
        RandomTagAssigner.usedTags.Clear();
        SampleSoundManager.Instance.StopBgm();
        SampleSoundManager.Instance.PlayBgm(BgmType.BGM4);
        SampleSoundManager.Instance.PlaySe(SeType.SE5);
        StartCoroutine(MoveToPosition(targetPosition, duration));
    }

    private System.Collections.IEnumerator MoveToPosition(Vector2 target, float time)
    {



        yield return new WaitForSeconds(1f);

       

        Vector2 startPosition = rectTransform.anchoredPosition; // ���݂̍��W
    
        float elapsedTime = 0;
        SampleSoundManager.Instance.PlaySe(SeType.SE4);
        // �w�肵�����Ԃ��o�߂���܂ŏ��X�Ɉړ�������
        while (elapsedTime < time)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null; // ���̃t���[���܂őҋ@
        }

        // �ŏI�I�Ƀ^�[�Q�b�g���W�ɃX�i�b�v
        rectTransform.anchoredPosition = target;
     
      
    }
}
