using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText; // テキストを表示するUI要素
   
    private float countdownDuration = 3f; // 3秒間のカウントダウン

    void Start()
    {
        if (!GameManager.isFirstStart)
        {
            this.gameObject.SetActive(true);
            StartCoroutine(StartCountdown());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator StartCountdown()
    {
        float timeLeft = countdownDuration;

        // カウントダウンが0になるまでループ
        while (timeLeft > 0)
        {
            // テキストに残り時間を表示
            countdownText.text =  Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f); // 1秒待つ
            timeLeft -= 1f;
        }

        // カウントダウン終了後にテキストを更新
        countdownText.text = "走れ!";

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
        GameManager.isFirstStart = true; // 初めだけカウントダウンするため

    }
}