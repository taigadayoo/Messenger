using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject imageChildObject;
    public float jumpForce = 7f;       // �W�����v���̗�
    [SerializeField]
    ButtanTextManager textManager;
    private Rigidbody2D rb;            // Rigidbody2D�̎Q��
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
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
    }

    void Update()
    {
        if (GameManager.isFirstStart)
        {
            // �E�����ɏ�Ɉړ�]
            if (!okDush)
            {
                rb.velocity = new Vector2(GameManager.playerSpeed,playerPosition.y);

            }
            else
            {
                rb.velocity = new Vector2(0, playerPosition.y);

            }
            // Space�L�[�����������ɃW�����v
            OnTouch();
        }
    }

    // �n�ʂƂ̐ڐG�𔻒�
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
        touchHuman = true;      // �Փ˂����I�u�W�F�N�g��SpriteRenderer�����邩�m�F
        SpriteRenderer otherSpriteRenderer = collision.GetComponent<SpriteRenderer>();

            if (otherSpriteRenderer != null)
            {
                // �q�I�u�W�F�N�g��Image�R���|�[�l���g���擾
                Image childImage = imageChildObject.GetComponent<Image>();

                if (childImage != null)
                {
                    // �Փ˂����I�u�W�F�N�g�̃X�v���C�g���q�I�u�W�F�N�g��Image�ɐݒ�
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
