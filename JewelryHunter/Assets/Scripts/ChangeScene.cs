using System.Collections;
using System.Collections.Generic;
//using Datadog.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 씬을 변경할 때 필요

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // 불러올 씬

    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        if(startButton)
            startButton.onClick.AddListener(Load);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 씬 불러오기
    public void Load()
    {
        //DatadogSdk.Instance.SetTrackingConsent(TrackingConsent.Granted);
        SceneManager.LoadScene(sceneName);
    }
}
