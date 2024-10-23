using UnityEngine;
using System.Collections.Generic;

public class RandomTagAssigner : MonoBehaviour
{
    public string[] tags; // タグのリスト
    public static List<string> usedTags = new List<string>(); // 既に使用されたタグを追跡するリスト

    void Start()
    {
        AssignUniqueRandomTag();
    }

    void AssignUniqueRandomTag()
    {
        // タグが空でないかを確認
        if (tags.Length > 0)
        {
            // 使用されていないタグをフィルタリング
            List<string> availableTags = new List<string>(tags);
            availableTags.RemoveAll(tag => usedTags.Contains(tag)); // 既に使われたタグを削除

            if (availableTags.Count > 0)
            {
                // ランダムにインデックスを選択してタグを設定
                int randomIndex = Random.Range(0, availableTags.Count);
                string selectedTag = availableTags[randomIndex];

                // GameObjectにタグを設定し、使用済みリストに追加
                gameObject.tag = selectedTag;
                usedTags.Add(selectedTag);

                Debug.Log($"Assigned unique tag: {selectedTag} to {gameObject.name}");
            }
            else
            {
                Debug.LogWarning("No available unique tags to assign.");
            }
        }
        else
        {
            Debug.LogWarning("No tags available to assign.");
        }
    }
}