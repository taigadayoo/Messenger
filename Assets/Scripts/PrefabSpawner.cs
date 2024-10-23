using UnityEngine;
using System.Collections.Generic;

public class PrefabSpawner : MonoBehaviour
{
    public List<GameObject> prefabs; // �z�u����v���n�u�̃��X�g
    public List<Vector2> spawnPositions; // �z�u������W�̃��X�g
    public string tagToAssign; // �t�^����^�O
    public string tagToAssign2; // �t�^����^�O

    private List<Vector2> availablePositions; // ���p�\�ȍ��W�̃��X�g

    void Start()
    {
        // ���p�\�ȍ��W��������
        availablePositions = new List<Vector2>(spawnPositions);
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        // �v���n�u���i�[���郊�X�g
        List<GameObject> spawnedObjects = new List<GameObject>();

        // ���X�g����ɂȂ�܂ŌJ��Ԃ�
        while (availablePositions.Count > 0 && prefabs.Count > 0)
        {
            // ���p�\�ȍ��W���烉���_���ɑI��
            int positionIndex = Random.Range(0, availablePositions.Count);
            Vector2 spawnPosition = availablePositions[positionIndex];

            // �v���n�u���X�g���烉���_���ɑI��
            int prefabIndex = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[prefabIndex];

            // �v���n�u�𐶐�
            GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            // ���������I�u�W�F�N�g�����X�g�ɒǉ�
            spawnedObjects.Add(spawnedObject);

            // �g�p�������W�����X�g����폜
            availablePositions.RemoveAt(positionIndex);
            // �g�p�����v���n�u�����X�g����폜�i���Ȃ��悤�ɂ��邽�߁j
            prefabs.RemoveAt(prefabIndex);
        }

        // ���������I�u�W�F�N�g�̒�����1�Ƀ^�O��t�^
        if (spawnedObjects.Count > 0)
        {
            // �ŏ��̃^�O�t�^
            int randomIndex = Random.Range(0, spawnedObjects.Count);
            spawnedObjects[randomIndex].tag = tagToAssign;
            Debug.Log($"Assigned tag: {tagToAssign} to {spawnedObjects[randomIndex].name}");

            // �c��̃v���n�u�̒�����1��tagToAssign2��t�^
            if (spawnedObjects.Count > 1)
            {
                List<GameObject> remainingObjects = new List<GameObject>(spawnedObjects);
                remainingObjects.RemoveAt(randomIndex); // ���ł�tagToAssign���t�^���ꂽ�I�u�W�F�N�g�����O

                int secondRandomIndex = Random.Range(0, remainingObjects.Count);
                remainingObjects[secondRandomIndex].tag = tagToAssign2;
                Debug.Log($"Assigned tag: {tagToAssign2} to {remainingObjects[secondRandomIndex].name}");
            }
        }
    }
}