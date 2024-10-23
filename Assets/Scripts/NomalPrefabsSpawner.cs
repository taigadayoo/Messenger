using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalPrefabsSpawner : MonoBehaviour
{
    public List<GameObject> prefabs; // 配置するプレハブのリスト
    public List<Vector2> spawnPositions; // 配置する座標のリスト

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

    }
}