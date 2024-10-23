using UnityEngine;
using TMPro; // TextMeshProを使用するため
using System.Collections.Generic;
public class AssignTextSprite : MonoBehaviour
{
    [System.Serializable]
    public class TaggedSprite
    {
        public Sprite sprite; // スプライト
        public string tagName; // スプライトに対応するタグ名
    }

    SpriteRenderer textSpriteRenderer;
    SpriteRenderer spriteRenderer;

    public List<TaggedSprite> sprites; // タグ付きスプライトのリスト
    public List<TaggedSprite> textSprites; // タグ付きテキストスプライトのリスト
    public GameObject spriteChildObject; // スプライトを表示する子オブジェクト
    public GameObject textChildObject; // テキストスプライトを表示する子オブジェクト

    public GameObject referenceObject1; // タグを参照するオブジェクト1
    public GameObject referenceObject2; // タグを参照するオブジェクト2
    public GameObject referenceObject3; // タグを参照するオブジェクト1
    public GameObject referenceObject4; // タグを参照するオブジェクト2
    private string myTag;
    private bool OneTag = false;
    private bool OneTag2 = false;
    void Start()
    {
        // 名前で参照するオブジェクトを探す
        referenceObject1 = GameObject.Find("HumanAnswer"); 
        referenceObject2 = GameObject.Find("MessegeAnswer");
        referenceObject3 = GameObject.Find("HumanAnswer2");
        referenceObject4 = GameObject.Find("MessegeAnswer2");

        // 子オブジェクトのSpriteRendererを取得
        spriteRenderer = spriteChildObject.GetComponent<SpriteRenderer>();
        textSpriteRenderer = textChildObject.GetComponent<SpriteRenderer>();

        // 自分のタグを取得
           myTag = gameObject.tag;

        // タグが"Message"の場合はスプライトを参照オブジェクトのタグに基づいて設定
    
    }
    private void Update()
    {
        if (myTag == "Messege" &&  !OneTag )
        {
            OneTag = true;

            // 参照するオブジェクトのタグを取得
            string tag1 = referenceObject1.tag; // referenceObject1のタグ
            string tag2 = referenceObject2.tag; // referenceObject2のタグ

            // タグに基づいてスプライトを取得して設定
            Sprite spriteToAssign = GetSpriteByTag(sprites, tag1);
            Sprite textSpriteToAssign = GetSpriteByTag(textSprites, tag2);

            if (spriteRenderer != null && spriteToAssign != null)
            {
                spriteRenderer.sprite = spriteToAssign; // タグに一致するスプライトを設定
            }

            if (textSpriteRenderer != null && textSpriteToAssign != null)
            {
                textSpriteRenderer.sprite = textSpriteToAssign; // タグに一致するテキストスプライトを設定
            }
        }
       else if (myTag == "Messege2" && !OneTag2)
        {
            OneTag2 = true;

            // 参照するオブジェクトのタグを取得
            string tag3 = referenceObject3.tag; 
            string tag4 = referenceObject4.tag; 

            // タグに基づいてスプライトを取得して設定
            Sprite spriteToAssign = GetSpriteByTag(sprites, tag3);
            Sprite textSpriteToAssign = GetSpriteByTag(textSprites, tag4);

            if (spriteRenderer != null && spriteToAssign != null)
            {
                spriteRenderer.sprite = spriteToAssign; // タグに一致するスプライトを設定
            }

            if (textSpriteRenderer != null && textSpriteToAssign != null)
            {
                textSpriteRenderer.sprite = textSpriteToAssign; // タグに一致するテキストスプライトを設定
            }
        }
        else if(!OneTag && myTag != "Messege2" && myTag != "Messege")
        {
            OneTag = true;
            // タグがMessage以外の場合はリストからランダムにスプライトを選択
            AssignRandomSprite(spriteRenderer, sprites);
            AssignRandomSprite(textSpriteRenderer, textSprites);
        }
    }
    // タグに基づいてスプライトを取得するメソッド
    private Sprite GetSpriteByTag(List<TaggedSprite> taggedSpriteList, string tag)
    {
        foreach (var taggedSprite in taggedSpriteList)
        {
            if (taggedSprite.tagName == tag) // タグ名が一致する場合
            {
                return taggedSprite.sprite; // 一致するスプライトを返す
            }
        }
        return null; // 見つからない場合はnullを返す
    }

    // リストからランダムにスプライトを設定するメソッド
    private void AssignRandomSprite(SpriteRenderer renderer, List<TaggedSprite> taggedSpriteList)
    {
        if (taggedSpriteList.Count > 0)
        {
            int randomSpriteIndex = Random.Range(0, taggedSpriteList.Count);
            if (renderer != null)
            {
                renderer.sprite = taggedSpriteList[randomSpriteIndex].sprite; // リストからランダムにスプライトを設定
            }
        }
    }
}