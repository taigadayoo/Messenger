using UnityEngine;
using TMPro; // TextMeshPro���g�p���邽��
using System.Collections.Generic;
public class AssignTextSprite : MonoBehaviour
{
    [System.Serializable]
    public class TaggedSprite
    {
        public Sprite sprite; // �X�v���C�g
        public string tagName; // �X�v���C�g�ɑΉ�����^�O��
    }

    SpriteRenderer textSpriteRenderer;
    SpriteRenderer spriteRenderer;

    public List<TaggedSprite> sprites; // �^�O�t���X�v���C�g�̃��X�g
    public List<TaggedSprite> textSprites; // �^�O�t���e�L�X�g�X�v���C�g�̃��X�g
    public GameObject spriteChildObject; // �X�v���C�g��\������q�I�u�W�F�N�g
    public GameObject textChildObject; // �e�L�X�g�X�v���C�g��\������q�I�u�W�F�N�g

    public GameObject referenceObject1; // �^�O���Q�Ƃ���I�u�W�F�N�g1
    public GameObject referenceObject2; // �^�O���Q�Ƃ���I�u�W�F�N�g2
    public GameObject referenceObject3; // �^�O���Q�Ƃ���I�u�W�F�N�g1
    public GameObject referenceObject4; // �^�O���Q�Ƃ���I�u�W�F�N�g2
    private string myTag;
    private bool OneTag = false;
    private bool OneTag2 = false;
    void Start()
    {
        // ���O�ŎQ�Ƃ���I�u�W�F�N�g��T��
        referenceObject1 = GameObject.Find("HumanAnswer"); 
        referenceObject2 = GameObject.Find("MessegeAnswer");
        referenceObject3 = GameObject.Find("HumanAnswer2");
        referenceObject4 = GameObject.Find("MessegeAnswer2");

        // �q�I�u�W�F�N�g��SpriteRenderer���擾
        spriteRenderer = spriteChildObject.GetComponent<SpriteRenderer>();
        textSpriteRenderer = textChildObject.GetComponent<SpriteRenderer>();

        // �����̃^�O���擾
           myTag = gameObject.tag;

        // �^�O��"Message"�̏ꍇ�̓X�v���C�g���Q�ƃI�u�W�F�N�g�̃^�O�Ɋ�Â��Đݒ�
    
    }
    private void Update()
    {
        if (myTag == "Messege" &&  !OneTag )
        {
            OneTag = true;

            // �Q�Ƃ���I�u�W�F�N�g�̃^�O���擾
            string tag1 = referenceObject1.tag; // referenceObject1�̃^�O
            string tag2 = referenceObject2.tag; // referenceObject2�̃^�O

            // �^�O�Ɋ�Â��ăX�v���C�g���擾���Đݒ�
            Sprite spriteToAssign = GetSpriteByTag(sprites, tag1);
            Sprite textSpriteToAssign = GetSpriteByTag(textSprites, tag2);

            if (spriteRenderer != null && spriteToAssign != null)
            {
                spriteRenderer.sprite = spriteToAssign; // �^�O�Ɉ�v����X�v���C�g��ݒ�
            }

            if (textSpriteRenderer != null && textSpriteToAssign != null)
            {
                textSpriteRenderer.sprite = textSpriteToAssign; // �^�O�Ɉ�v����e�L�X�g�X�v���C�g��ݒ�
            }
        }
       else if (myTag == "Messege2" && !OneTag2)
        {
            OneTag2 = true;

            // �Q�Ƃ���I�u�W�F�N�g�̃^�O���擾
            string tag3 = referenceObject3.tag; 
            string tag4 = referenceObject4.tag; 

            // �^�O�Ɋ�Â��ăX�v���C�g���擾���Đݒ�
            Sprite spriteToAssign = GetSpriteByTag(sprites, tag3);
            Sprite textSpriteToAssign = GetSpriteByTag(textSprites, tag4);

            if (spriteRenderer != null && spriteToAssign != null)
            {
                spriteRenderer.sprite = spriteToAssign; // �^�O�Ɉ�v����X�v���C�g��ݒ�
            }

            if (textSpriteRenderer != null && textSpriteToAssign != null)
            {
                textSpriteRenderer.sprite = textSpriteToAssign; // �^�O�Ɉ�v����e�L�X�g�X�v���C�g��ݒ�
            }
        }
        else if(!OneTag && myTag != "Messege2" && myTag != "Messege")
        {
            OneTag = true;
            // �^�O��Message�ȊO�̏ꍇ�̓��X�g���烉���_���ɃX�v���C�g��I��
            AssignRandomSprite(spriteRenderer, sprites);
            AssignRandomSprite(textSpriteRenderer, textSprites);
        }
    }
    // �^�O�Ɋ�Â��ăX�v���C�g���擾���郁�\�b�h
    private Sprite GetSpriteByTag(List<TaggedSprite> taggedSpriteList, string tag)
    {
        foreach (var taggedSprite in taggedSpriteList)
        {
            if (taggedSprite.tagName == tag) // �^�O������v����ꍇ
            {
                return taggedSprite.sprite; // ��v����X�v���C�g��Ԃ�
            }
        }
        return null; // ������Ȃ��ꍇ��null��Ԃ�
    }

    // ���X�g���烉���_���ɃX�v���C�g��ݒ肷�郁�\�b�h
    private void AssignRandomSprite(SpriteRenderer renderer, List<TaggedSprite> taggedSpriteList)
    {
        if (taggedSpriteList.Count > 0)
        {
            int randomSpriteIndex = Random.Range(0, taggedSpriteList.Count);
            if (renderer != null)
            {
                renderer.sprite = taggedSpriteList[randomSpriteIndex].sprite; // ���X�g���烉���_���ɃX�v���C�g��ݒ�
            }
        }
    }
}