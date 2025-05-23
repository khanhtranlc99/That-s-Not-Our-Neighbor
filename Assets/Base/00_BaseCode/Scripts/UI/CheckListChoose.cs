using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckListChoose : MonoBehaviour
{
    public KeyType keyType;
    public CheckListBox checkListBox;
    public Button btnRight;
    public Button btnWrong;
    public GameObject vObj;
    public GameObject xObj;
    public bool isCheck;

    public void Init()
    {
        isCheck = false;
        btnRight.onClick.AddListener(HandleBtnRight);
        btnWrong.onClick.AddListener(HandleBtnLeft);
    }   
    public void HandleBtnRight()
    {
        if(!vObj.activeSelf)
        {
            xObj.SetActive(false);
            vObj.SetActive(true);
        }
        else
        {
            vObj.SetActive(false);
        }
        isCheck = true;
        if(checkListBox.AllCheckOk)
        {
            GamePlayController.Instance.playerContain.completeChoose = true;
            GamePlayController.Instance.playerContain.doorController.objClose.HandleScaleLoop();
            GamePlayController.Instance.playerContain.doorController.objOpen.HandleScaleLoop();
        }
        HandleCheck(true);
    }
    public void HandleBtnLeft()
    {
        if (!xObj.activeSelf)
        {
            vObj.SetActive(false);
            xObj.SetActive(true);
        }
        else
        {
            xObj.SetActive(false);
        }
        isCheck = true;
        if (checkListBox.AllCheckOk)
        {
            GamePlayController.Instance.playerContain.completeChoose = true;
            GamePlayController.Instance.playerContain.doorController.objClose.HandleScaleLoop();
            GamePlayController.Instance.playerContain.doorController.objOpen.HandleScaleLoop();
        }
        HandleCheck(false);
    }
    public void HandleCheck(bool isTrue)
    {

        GamePlayController.Instance.playerContain.answerController.GetKeyAnswer(keyType).correct = isTrue;
    }    

}
