using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalPrefabsSpawner : MonoBehaviour
{
    public List<GameObject> prefabs; // �z�u����v���n�u�̃��X�g
    public List<Vector2> spawnPositions; // �z�u������W�̃��X�g

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

    }
}