using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjInGame : MonoBehaviour
{
    public ObjType objType;
    Vector3 firstPost;
    public void Start()
    {
        firstPost = transform.localScale;
    }

    public void HandlShowBox()
    {
      

        switch (objType)
            {
                case ObjType.Card_Id:
                    CardInfoBox.Setup(GamePlayController.Instance.playerContain.levelData.dataCharector).Show();
                    break;
                case ObjType.Paper:
                    CheckListBox.Setup(GamePlayController.Instance.playerContain.levelData.dataCharector).Show();
                    break;
                case ObjType.ToDayList:
                    TodayListBox.Setup(GamePlayController.Instance.playerContain.levelData.lsDataCharector).Show();
                    break;
                case ObjType.Folder:
                    FolderBox.Setup(GamePlayController.Instance.playerContain.levelData.lsDataCharector).Show();
                    break;
                case ObjType.ButtonCloseDoor:
                     GamePlayController.Instance.playerContain.doorController.HandleBtnCloseDoor();
                    break;
                case ObjType.ButtonOpenDoor:
                     GamePlayController.Instance.playerContain.doorController.HandleBtnOpenDoor();
                break;
            }
       
    }

    public void HandleScale()
    {
        this.transform.DOKill();
        this.transform.DOScale(firstPost * 1.2f,0.3f).OnComplete(delegate
        {
            this.transform.DOScale(firstPost, 0.3f).OnComplete(delegate
            {
                this.transform.DOScale(firstPost * 1.2f, 0.3f).OnComplete(delegate
                {
                    this.transform.DOScale(firstPost, 0.3f).OnComplete(delegate
                    {

                    });
                });
            });
        });
    }
    public void HandleScaleLoop()
    {
        this.transform.DOScale(firstPost * 1.1f, 0.3f).OnComplete(delegate
        {
            this.transform.DOScale(firstPost, 0.3f).OnComplete(delegate
            {
                HandleScaleLoop();
            });
        });
    }
}

public enum ObjType
{
    None,
    Card_Id,
    Paper,
    ToDayList,
    Folder,
    ButtonCloseDoor,
    ButtonOpenDoor,
}