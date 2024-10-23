using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssign : MonoBehaviour
{
    public List<Sprite> sprites; // Sprite�̃��X�g
    public GameObject spriteChildObject; // �X�v���C�g��\������q�I�u�W�F�N�g

    void Start()
    {

        SpriteRenderer spriteRenderer = spriteChildObject.GetComponent<SpriteRenderer>();

        // ���������̃T�C�Y���擾
        int minCount = Mathf.Min(sprites.Count);

      int i = Random.Range(0,sprites.Count); 

            // �X�v���C�g�ƃe�L�X�g��ݒ�
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[i];
            }


        // �c��̃X�v���C�g��e�L�X�g������ꍇ�̏����i�I�v�V�����j
        if (sprites.Count > minCount)
        {
            // �]�����X�v���C�g�ɑ΂��鏈���i��: �Ō�̃X�v���C�g��ݒ�j
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[minCount - 1];
            }
        }

    }
}