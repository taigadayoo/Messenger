using UnityEngine;
using System.Collections.Generic;

public class RandomTagAssigner : MonoBehaviour
{
    public string[] tags; // �^�O�̃��X�g
    public static List<string> usedTags = new List<string>(); // ���Ɏg�p���ꂽ�^�O��ǐՂ��郊�X�g

    void Start()
    {
        AssignUniqueRandomTag();
    }

    void AssignUniqueRandomTag()
    {
        // �^�O����łȂ������m�F
        if (tags.Length > 0)
        {
            // �g�p����Ă��Ȃ��^�O���t�B���^�����O
            List<string> availableTags = new List<string>(tags);
            availableTags.RemoveAll(tag => usedTags.Contains(tag)); // ���Ɏg��ꂽ�^�O���폜

            if (availableTags.Count > 0)
            {
                // �����_���ɃC���f�b�N�X��I�����ă^�O��ݒ�
                int randomIndex = Random.Range(0, availableTags.Count);
                string selectedTag = availableTags[randomIndex];

                // GameObject�Ƀ^�O��ݒ肵�A�g�p�ς݃��X�g�ɒǉ�
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