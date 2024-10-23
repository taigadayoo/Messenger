using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtanTextManager : MonoBehaviour
{
    [System.Serializable]
    public class TaggedText
    {
        public Text textComponent; // Text�R���|�[�l���g
        public string key; // ����̕�����L�[
        public string fixedText; // �Œ�̃e�L�X�g
    }

    public List<TaggedText> texts; // �K���\��������������ƑΉ�����e�L�X�g�̃��X�g
    public List<string> randomTextList; // �����_���őI������e�L�X�g�̃��X�g

    public GameObject messegeObj;
    private string referenceTag; // `referenceObject2` �̃^�O���i�[����
    public GameObject messegeObj2;
    public string referenceTag2; // `referenceObject4` �̃^�O���i�[����
    public bool clearText = false;
    private bool oneTag = false;    
    public bool isAnsewer2;
    void Start()
    {
        // `referenceObject2` �̃^�O���擾

       
        Debug.Log($"Reference Tag: {referenceTag}");

    }
    private void OnEnable()
    {
        AssignTexts(); 
    }
    private void Update()
    {
        if (!oneTag)
        {
            referenceTag = messegeObj.tag;
            referenceTag2 = messegeObj2.tag;
            oneTag = true;
        }
        if(referenceTag != null && referenceTag2 != null && !clearText)
        {
            AssignTexts();
            clearText = true;
        }

    }
    public  void AssignTexts()
    {
        bool requiredTextAssigned = false; // �Œ�e�L�X�g���ݒ肳�ꂽ���ǂ����̃t���O
        List<string> usedTexts = new List<string>(); // �g�p�ς݂̃����_���e�L�X�g�̊Ǘ����X�g

        if (!isAnsewer2)
        {
            foreach (var taggedText in texts)
            {
                if (taggedText.key == referenceTag && !requiredTextAssigned)
                {
                    // `referenceTag` �ƃL�[����v����ꍇ�A�Œ�e�L�X�g�����蓖��
                    taggedText.textComponent.text = taggedText.fixedText;
                    requiredTextAssigned = true;
                    Debug.Log($"Assigned fixed text: {taggedText.fixedText} to {taggedText.textComponent.name}");

                    // ���̊K�w�̐e�I�u�W�F�N�g�̃^�O�� "Answer" �ɐݒ�
                    Transform parentObject = taggedText.textComponent.transform.parent;
                    if (parentObject != null)
                    {
                        parentObject.tag = "Answer";
                        Debug.Log($"Set tag 'Answer' to the parent object: {parentObject.name}");
                    }
                }
                else
                {
                    // �����_���ȃe�L�X�g���擾���āA�d�����Ȃ��悤�ɐݒ�
                    string randomText = GetUniqueRandomText(usedTexts);
                    taggedText.textComponent.text = randomText;
                    usedTexts.Add(randomText);
                }
            }
        }
        if (isAnsewer2)
        {
            foreach (var taggedText in texts)
            {
                 if (taggedText.key == referenceTag2 && !requiredTextAssigned && isAnsewer2)
                {
                    // `referenceTag` �ƃL�[����v����ꍇ�A�Œ�e�L�X�g�����蓖��
                    taggedText.textComponent.text = taggedText.fixedText;
                    requiredTextAssigned = true;
                    Debug.Log($"Assigned fixed text: {taggedText.fixedText} to {taggedText.textComponent.name}");

                    // ���̊K�w�̐e�I�u�W�F�N�g�̃^�O�� "Answer" �ɐݒ�
                    Transform parentObject = taggedText.textComponent.transform.parent;
                    if (parentObject != null)
                    {
                        parentObject.tag = "Answer2";
                        Debug.Log($"Set tag 'Answer' to the parent object: {parentObject.name}");
                    }
                }
                else
                {
                    // �����_���ȃe�L�X�g���擾���āA�d�����Ȃ��悤�ɐݒ�
                    string randomText = GetUniqueRandomText(usedTexts);
                    taggedText.textComponent.text = randomText;
                    usedTexts.Add(randomText);
                }
            }
        }
    }

    // �g�p�ς݃��X�g�Əd�����Ȃ������_���e�L�X�g���擾
    string GetUniqueRandomText(List<string> usedTexts)
    {
        List<string> availableTexts = new List<string>(randomTextList);
        availableTexts.RemoveAll(text => usedTexts.Contains(text));

        if (availableTexts.Count == 0)
        {
            Debug.LogWarning("No available texts left.");
            return "";
        }

        int randomIndex = Random.Range(0, availableTexts.Count);
        return availableTexts[randomIndex];
    }
}