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
        // 既にインスタンスが存在する場合は、重複しないようにこのオブジェクトを破棄する
        if (sceneInstance != null && sceneInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // インスタンスがまだ存在しない場合、このオブジェクトをシングルトンとして設定し、破棄されないようにする
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
