using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerJudge : MonoBehaviour
{
    private string referenceTag; // SpriteTextAssignerのreferenceObject1のタグを保持
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
        // 触れたオブジェクトのタグを確認
        string otherTag = other.gameObject.tag;

        // referenceObject1のタグと一致するか確認
        if (otherTag == referenceTag)
        {
            humanClear = true;
            // タグが一致した場合の処理

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