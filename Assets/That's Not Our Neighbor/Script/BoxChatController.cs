using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using System;
using UnityEngine.Experimental.GlobalIllumination;

public class BoxChatController : MonoBehaviour
{
    public GameObject boxChat;
    public Text tvContent;
    public Button btnSkip;
    public Tween tweenTv;
    Action callbackBox;
    public Coroutine ieShowTv;
    public void Init()
    {
        tvContent.text = "";
        btnSkip.onClick.AddListener(HandleSkip);
    }

    public void ShowTextTypewriter(string text, float delay, Action callBack)
    {
        ieShowTv = StartCoroutine(IEShowText(text, delay, callBack)); 
    }    

    public IEnumerator IEShowText(string text, float delay, Action callBack)
    {
        callbackBox = null;
        tweenTv?.Kill(); // Nếu có tween đang chạy thì dừng lại
        boxChat.SetActive(true);
        tvContent.text = "";
        callbackBox = callBack;
        int length = text.Length;

        tweenTv = DOTween.To(() => 0, i =>
        {
            tvContent.text = text.Substring(0, i);
        }, length, length * delay)
        .SetEase(Ease.Linear);

        yield return tweenTv.WaitForCompletion();

        yield return new WaitForSeconds(2);
        Debug.LogError("123456");
        boxChat.SetActive(false);
        callbackBox?.Invoke();
    }
    private void HandleSkip()
    {
        if(ieShowTv != null )
        {
            StopCoroutine(ieShowTv);
            ieShowTv = null;
        }    
        tweenTv?.Kill();
        callbackBox?.Invoke();
        boxChat.SetActive(false);

    }    

}
