using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(DelayCall());
        //StartCoroutine(GetRequestCoroutine("www.naver.com", (_) => { }));
        //StartCoroutine(GetRequestCoroutine("www.naver.com", CallBack));
    }

    public void CallBack(string value)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D : " + other.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay2D : " + other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D : " + other.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D : " + other.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("OnCollisionStay2D : " + other.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("OnCollisionExit2D : " + other.gameObject.name);
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
    
    IEnumerator DelayCall()
    {
        //시작
        yield return new WaitForSeconds(.1f);
        //1초후 다음 코드
        yield return null;
        //다음 프레임까지 대기후 다음 코드
    }
    
    private IEnumerator GetRequestCoroutine(string url, Action<string> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("GET request error: " + www.error);
            callback?.Invoke(null);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log("GET request successful!");
            Debug.Log("Response: " + response);
            callback?.Invoke(response);
        }
        
        www.Dispose();
    }
}
