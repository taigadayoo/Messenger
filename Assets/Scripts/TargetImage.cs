using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImage : MonoBehaviour
{
    public string targetTag = "Messege"; // �^�O���w��
    public string targetTag2 = "Messege2"; // �^�O���w��
    public SpriteRenderer targetSpriteRenderer; // �X�v���C�g��\������SpriteRenderer
    public SpriteRenderer targetSpriteRenderer2; // �X�v���C�g��\������SpriteRenderer
    private bool oneImage = false;
    public Camera mainCamera;

    // �\���������X�N���[�����W�i�s�N�Z���j
    public Vector2 screenPosition = new Vector2(100, 100);
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    private void Update()
    {
        if(!oneImage && GameManager.isFirstStart)
        {
            StartCoroutine(HukidasiAnim());
            oneImage = true;
        }
          // �X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));

        // Z���W�̒����i2D�̏ꍇ�A�ʏ��0���g�p�j
        worldPosition.z = 0f;

        // �I�u�W�F�N�g�̈ʒu���X�V
        transform.position = worldPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OffCol")
        {
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator HukidasiAnim()
    {

        animator.enabled = true;
        spriteRenderer.enabled = true;
        SampleSoundManager.Instance.PlaySe(SeType.SE1);
        yield return new WaitForSeconds(1f);
        
        DisplayUniqueTagSprite();

       
    }
    void DisplayUniqueTagSprite()
    {
        // �w�肵���^�O�����I�u�W�F�N�g������
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject[] taggedObjects2 = GameObject.FindGameObjectsWithTag(targetTag2);

        // �^�O�����I�u�W�F�N�g��������Ȃ��ꍇ
        if (taggedObjects.Length == 0)
        {
            Debug.LogWarning($"No object found with tag: {targetTag}");
            return;
        }
        if (taggedObjects2.Length == 0)
        {
            Debug.LogWarning($"No object found with tag: {targetTag}");
            return;
        }

        // �ŏ��̃I�u�W�F�N�g�̃X�v���C�g���擾
        SpriteRenderer foundSpriteRenderer = taggedObjects[0].GetComponent<SpriteRenderer>();
        SpriteRenderer foundSpriteRenderer2 = taggedObjects2[0].GetComponent<SpriteRenderer>();

        if (foundSpriteRenderer != null && targetSpriteRenderer != null)
        {
            // �X�v���C�g��ݒ�
            targetSpriteRenderer.sprite = foundSpriteRenderer.sprite;
        }
        if (foundSpriteRenderer2 != null && targetSpriteRenderer2 != null)
        {
            // �X�v���C�g��ݒ�
            targetSpriteRenderer2.sprite = foundSpriteRenderer2.sprite;
        }
        else
        {
            Debug.LogWarning("The found object does not have a SpriteRenderer or targetSpriteRenderer is null.");
        }
    }
}