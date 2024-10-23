using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImage : MonoBehaviour
{
    public string targetTag = "Messege"; // タグを指定
    public string targetTag2 = "Messege2"; // タグを指定
    public SpriteRenderer targetSpriteRenderer; // スプライトを表示するSpriteRenderer
    public SpriteRenderer targetSpriteRenderer2; // スプライトを表示するSpriteRenderer
    private bool oneImage = false;
    public Camera mainCamera;

    // 表示したいスクリーン座標（ピクセル）
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
          // スクリーン座標をワールド座標に変換
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));

        // Z座標の調整（2Dの場合、通常は0を使用）
        worldPosition.z = 0f;

        // オブジェクトの位置を更新
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
        // 指定したタグを持つオブジェクトを検索
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject[] taggedObjects2 = GameObject.FindGameObjectsWithTag(targetTag2);

        // タグを持つオブジェクトが見つからない場合
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

        // 最初のオブジェクトのスプライトを取得
        SpriteRenderer foundSpriteRenderer = taggedObjects[0].GetComponent<SpriteRenderer>();
        SpriteRenderer foundSpriteRenderer2 = taggedObjects2[0].GetComponent<SpriteRenderer>();

        if (foundSpriteRenderer != null && targetSpriteRenderer != null)
        {
            // スプライトを設定
            targetSpriteRenderer.sprite = foundSpriteRenderer.sprite;
        }
        if (foundSpriteRenderer2 != null && targetSpriteRenderer2 != null)
        {
            // スプライトを設定
            targetSpriteRenderer2.sprite = foundSpriteRenderer2.sprite;
        }
        else
        {
            Debug.LogWarning("The found object does not have a SpriteRenderer or targetSpriteRenderer is null.");
        }
    }
}