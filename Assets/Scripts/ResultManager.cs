using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    public Text scoreText; // Textコンポーネントをアタッチ

    public RectTransform rectTransform; // 移動させるRectTransform
    public Vector2 targetPosition;      // 移動先の座標
    public float duration = 1.0f;       // 移動にかける時間
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

       

        Vector2 startPosition = rectTransform.anchoredPosition; // 現在の座標
    
        float elapsedTime = 0;
        SampleSoundManager.Instance.PlaySe(SeType.SE4);
        // 指定した時間が経過するまで徐々に移動させる
        while (elapsedTime < time)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null; // 次のフレームまで待機
        }

        // 最終的にターゲット座標にスナップ
        rectTransform.anchoredPosition = target;
     
      
    }
}
