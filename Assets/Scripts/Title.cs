using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SampleSoundManager.Instance.StopBgm();
        SampleSoundManager.Instance.PlayBgm(BgmType.BGM1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManagement.sceneInstance.OnGame();
            SampleSoundManager.Instance.StopBgm();
            SampleSoundManager.Instance.PlayBgm(BgmType.BGM2);
        }
    }
}
