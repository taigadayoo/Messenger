using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject imageChildObject;
    public float jumpForce = 7f;       // ジャンプ時の力
    [SerializeField]
    ButtanTextManager textManager;
    private Rigidbody2D rb;            // Rigidbody2Dの参照
    public GameObject answerPanel;
    public bool touchHuman = false;
    public bool okDush = false;
    private bool on2Ansewer = false;
    public bool stopAssign = false;
    public GameObject messegeAnsewer;
    public GameObject hukidasi;
    private Vector2 playerPosition;
    [SerializeField]
    ResultManager resultManager;
    void Start()
    {
        playerPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    void Update()
    {
        if (GameManager.isFirstStart)
        {
            // 右方向に常に移動]
            if (!okDush)
            {
                rb.velocity = new Vector2(GameManager.playerSpeed,playerPosition.y);

            }
            else
            {
                rb.velocity = new Vector2(0, playerPosition.y);

            }
            // Spaceキーを押した時にジャンプ
            OnTouch();
        }
    }

    // 地面との接触を判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dead")
        {
            resultManager.OnGameOver();
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OffCol")
        {
            hukidasi.gameObject.SetActive(false);
        }
        touchHuman = true;      // 衝突したオブジェクトにSpriteRendererがあるか確認
        SpriteRenderer otherSpriteRenderer = collision.GetComponent<SpriteRenderer>();

            if (otherSpriteRenderer != null)
            {
                // 子オブジェクトのImageコンポーネントを取得
                Image childImage = imageChildObject.GetComponent<Image>();

                if (childImage != null)
                {
                    // 衝突したオブジェクトのスプライトを子オブジェクトのImageに設定
                    childImage.sprite = otherSpriteRenderer.sprite;
                 
                }
                else
                {
                    Debug.LogWarning($"The object {imageChildObject.name} does not have an Image component.");
                }
            }
            else
            {
                Debug.LogWarning($"The object {collision.gameObject.name} does not have a SpriteRenderer component.");
            }

            
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == messegeAnsewer.tag)
        {
            on2Ansewer = true;
        }
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touchHuman = false;

        on2Ansewer = false;
    }
    private void OnTouch()
    {
        if(touchHuman && Input.GetKeyDown(KeyCode.Space))
        {
            SampleSoundManager.Instance.PlaySe(SeType.SE2);
            if (touchHuman && !stopAssign)
            {
                if (on2Ansewer)
                {
                    textManager.isAnsewer2 = true;
                    textManager.AssignTexts();
                 
                }
                else
                {
                    textManager.isAnsewer2 = false;
                    textManager.AssignTexts();
                }
            
                answerPanel.SetActive(true);
                stopAssign = true;
             okDush = true;
            }
        }
    }
}
