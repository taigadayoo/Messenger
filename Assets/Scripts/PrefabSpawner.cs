using UnityEngine;
using System.Collections.Generic;

public class PrefabSpawner : MonoBehaviour
{
    public List<GameObject> prefabs; // 配置するプレハブのリスト
    public List<Vector2> spawnPositions; // 配置する座標のリスト
    public string tagToAssign; // 付与するタグ
    public string tagToAssign2; // 付与するタグ

    private List<Vector2> availablePositions; // 利用可能な座標のリスト

    void Start()
    {
        // 利用可能な座標を初期化
        availablePositions = new List<Vector2>(spawnPositions);
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        // プレハブを格納するリスト
        List<GameObject> spawnedObjects = new List<GameObject>();

        // リストが空になるまで繰り返す
        while (availablePositions.Count > 0 && prefabs.Count > 0)
        {
            // 利用可能な座標からランダムに選択
            int positionIndex = Random.Range(0, availablePositions.Count);
            Vector2 spawnPosition = availablePositions[positionIndex];

            // プレハブリストからランダムに選択
            int prefabIndex = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[prefabIndex];

            // プレハブを生成
            GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            // 生成したオブジェクトをリストに追加
            spawnedObjects.Add(spawnedObject);

            // 使用した座標をリストから削除
            availablePositions.RemoveAt(positionIndex);
            // 使用したプレハブをリストから削除（被らないようにするため）
            prefabs.RemoveAt(prefabIndex);
        }

        // 生成したオブジェクトの中から1つにタグを付与
        if (spawnedObjects.Count > 0)
        {
            // 最初のタグ付与
            int randomIndex = Random.Range(0, spawnedObjects.Count);
            spawnedObjects[randomIndex].tag = tagToAssign;
            Debug.Log($"Assigned tag: {tagToAssign} to {spawnedObjects[randomIndex].name}");

            // 残りのプレハブの中から1つにtagToAssign2を付与
            if (spawnedObjects.Count > 1)
            {
                List<GameObject> remainingObjects = new List<GameObject>(spawnedObjects);
                remainingObjects.RemoveAt(randomIndex); // すでにtagToAssignが付与されたオブジェクトを除外

                int secondRandomIndex = Random.Range(0, remainingObjects.Count);
                remainingObjects[secondRandomIndex].tag = tagToAssign2;
                Debug.Log($"Assigned tag: {tagToAssign2} to {remainingObjects[secondRandomIndex].name}");
            }
        }
    }
}