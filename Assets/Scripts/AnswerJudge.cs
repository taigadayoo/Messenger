using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerJudge : MonoBehaviour
{
    private string referenceTag; // SpriteTextAssigner��referenceObject1�̃^�O��ێ�
    private string referenceTag2;
    private bool oneTagGet = false;
    private bool oneTagGet2 = false;
    public GameObject tagGetObject;
    public GameObject tagGetObject2;

    public bool humanClear = false;
    public bool humanClear2 = false;
    public bool messegeClear = false;
    void Start()
    {
        
    }
    private void Update()
    {
        if ( !oneTagGet)
        {
            referenceTag = tagGetObject.tag;
            oneTagGet = true;
        }
        if (!oneTagGet2)
        {
            referenceTag2 = tagGetObject2.tag;
            oneTagGet2 = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ꂽ�I�u�W�F�N�g�̃^�O���m�F
        string otherTag = other.gameObject.tag;

        // referenceObject1�̃^�O�ƈ�v���邩�m�F
        if (otherTag == referenceTag)
        {
            humanClear = true;
            // �^�O����v�����ꍇ�̏���

        }
        else if (otherTag == referenceTag2)
        {
            humanClear2 = true;

        }
        else
        {
            humanClear = false;
            humanClear2 = false;
        }
    }
}