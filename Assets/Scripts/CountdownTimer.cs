using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText; // �e�L�X�g��\������UI�v�f
   
    private float countdownDuration = 3f; // 3�b�Ԃ̃J�E���g�_�E��

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

        // �J�E���g�_�E����0�ɂȂ�܂Ń��[�v
        while (timeLeft > 0)
        {
            // �e�L�X�g�Ɏc�莞�Ԃ�\��
            countdownText.text =  Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f); // 1�b�҂�
            timeLeft -= 1f;
        }

        // �J�E���g�_�E���I����Ƀe�L�X�g���X�V
        countdownText.text = "����!";

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
        GameManager.isFirstStart = true; // ���߂����J�E���g�_�E�����邽��

    }
}