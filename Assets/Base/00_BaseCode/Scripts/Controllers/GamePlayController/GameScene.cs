using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{
 
    public Text tvLevel;
    public Button settinBtn;
    public Transform canvas;
    public GraphicRaycaster graphicRaycaster; // Tham chiếu đến GraphicRaycaster
    private EventSystem eventSystem;
    public bool IsMouseClickingOnImage
    {
        get
        {
#if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
                return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
            else
                return false;
#else
        return EventSystem.current.IsPointerOverGameObject();
#endif
        }

    }

    public void Init(LevelData levelData)
    {
    
     
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {
     
    }
}
