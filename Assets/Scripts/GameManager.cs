using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // static�ȕϐ��B���ׂẴV�[���ŋ��L�����
    public static int clearHuman = 0;�@//�X�R�A
    public static int playerSpeed = 5;//player�̑��x
    public static bool isFirstStart = false;
    void Awake()
    {
        // ���ɃC���X�^���X�����݂���ꍇ�́A�d�����Ȃ��悤�ɂ��̃I�u�W�F�N�g��j������
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // �C���X�^���X���܂����݂��Ȃ��ꍇ�A���̃I�u�W�F�N�g���V���O���g���Ƃ��Đݒ肵�A�j������Ȃ��悤�ɂ���
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // static�Ȋ֐�
    private void Start()
    {
      
    }
    private void Update()
    {
     
       
    }
    // ��static�Ȋ֐�
    public void ResetGame()
    {
        clearHuman = 0;
        playerSpeed = 5;
    }
}