using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string sceneNameGame;
    [SerializeField] private string sceneNameGameOver;
    [SerializeField] private string sceneNameTitle;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeSpeed;
    public static SceneManagement sceneInstance { get; private set; }
    void Awake()
    {
        // ���ɃC���X�^���X�����݂���ꍇ�́A�d�����Ȃ��悤�ɂ��̃I�u�W�F�N�g��j������
        if (sceneInstance != null && sceneInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // �C���X�^���X���܂����݂��Ȃ��ꍇ�A���̃I�u�W�F�N�g���V���O���g���Ƃ��Đݒ肵�A�j������Ȃ��悤�ɂ���
            sceneInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
    }
    public void OnGame()
    {
        Initiate.Fade(sceneNameGame, fadeColor, fadeSpeed);
    }
    public void OnTitle()
    {
        Initiate.Fade(sceneNameTitle, fadeColor, fadeSpeed);
    }

    void Update()
    {
        
    }
}
