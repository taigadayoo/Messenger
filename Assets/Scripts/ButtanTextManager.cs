using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtanTextManager : MonoBehaviour
{
    [System.Serializable]
    public class TaggedText
    {
        public Text textComponent; // Textコンポーネント
        public string key; // 特定の文字列キー
        public string fixedText; // 固定のテキスト
    }

    public List<TaggedText> texts; // 必ず表示したい文字列と対応するテキストのリスト
    public List<string> randomTextList; // ランダムで選択するテキストのリスト

    public GameObject messegeObj;
    private string referenceTag; // `referenceObject2` のタグを格納する
    public GameObject messegeObj2;
    public string referenceTag2; // `referenceObject4` のタグを格納する
    public bool clearText = false;
    private bool oneTag = false;    
    public bool isAnsewer2;
    void Start()
    {
        // `referenceObject2` のタグを取得

       
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
        bool requiredTextAssigned = false; // 固定テキストが設定されたかどうかのフラグ
        List<string> usedTexts = new List<string>(); // 使用済みのランダムテキストの管理リスト

        if (!isAnsewer2)
        {
            foreach (var taggedText in texts)
            {
                if (taggedText.key == referenceTag && !requiredTextAssigned)
                {
                    // `referenceTag` とキーが一致する場合、固定テキストを割り当て
                    taggedText.textComponent.text = taggedText.fixedText;
                    requiredTextAssigned = true;
                    Debug.Log($"Assigned fixed text: {taggedText.fixedText} to {taggedText.textComponent.name}");

                    // 一個上の階層の親オブジェクトのタグを "Answer" に設定
                    Transform parentObject = taggedText.textComponent.transform.parent;
                    if (parentObject != null)
                    {
                        parentObject.tag = "Answer";
                        Debug.Log($"Set tag 'Answer' to the parent object: {parentObject.name}");
                    }
                }
                else
                {
                    // ランダムなテキストを取得して、重複しないように設定
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
                    // `referenceTag` とキーが一致する場合、固定テキストを割り当て
                    taggedText.textComponent.text = taggedText.fixedText;
                    requiredTextAssigned = true;
                    Debug.Log($"Assigned fixed text: {taggedText.fixedText} to {taggedText.textComponent.name}");

                    // 一個上の階層の親オブジェクトのタグを "Answer" に設定
                    Transform parentObject = taggedText.textComponent.transform.parent;
                    if (parentObject != null)
                    {
                        parentObject.tag = "Answer2";
                        Debug.Log($"Set tag 'Answer' to the parent object: {parentObject.name}");
                    }
                }
                else
                {
                    // ランダムなテキストを取得して、重複しないように設定
                    string randomText = GetUniqueRandomText(usedTexts);
                    taggedText.textComponent.text = randomText;
                    usedTexts.Add(randomText);
                }
            }
        }
    }

    // 使用済みリストと重複しないランダムテキストを取得
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