using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssign : MonoBehaviour
{
    public List<Sprite> sprites; // Spriteのリスト
    public GameObject spriteChildObject; // スプライトを表示する子オブジェクト

    void Start()
    {

        SpriteRenderer spriteRenderer = spriteChildObject.GetComponent<SpriteRenderer>();

        // 小さい方のサイズを取得
        int minCount = Mathf.Min(sprites.Count);

      int i = Random.Range(0,sprites.Count); 

            // スプライトとテキストを設定
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[i];
            }


        // 残りのスプライトやテキストがある場合の処理（オプション）
        if (sprites.Count > minCount)
        {
            // 余ったスプライトに対する処理（例: 最後のスプライトを設定）
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[minCount - 1];
            }
        }

    }
}