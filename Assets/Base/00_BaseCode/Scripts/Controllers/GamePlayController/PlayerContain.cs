using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
public class PlayerContain : MonoBehaviour
{
    public LevelData levelData;
    public DoorController doorController;
    public StaffController staffController;
    public BoxChatController boxChatController;
    public AnswerController answerController;
    public Transform postLeft;
    public Transform postMid;
    public ObjInGame cardObj;
    public Transform postCardUp;
    public Transform postCardDown;
    public bool completeChoose;

    public void Init()
    {
        string pathLevel = StringHelper.PATH_CONFIG_LEVEL_TEST;
        levelData = Instantiate(Resources.Load<LevelData>(string.Format(pathLevel, UseProfile.CurrentLevel)));
        completeChoose = false;
        levelData.Init(this);
        doorController.Init();
        staffController.Init();
        boxChatController.Init();
        cardObj.transform.position = postCardUp.position;
        StartCoroutine( HandleIntro());
    }


    public IEnumerator HandleIntro()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(doorController.HandleMoveDoor(true, delegate
        {
            StartCoroutine(HandleStaff());

        }));
          

    }
    public IEnumerator HandleStaff()
    {
        yield return new WaitForSeconds(1);
        staffController.HandelScaleInOut();
        boxChatController.ShowTextTypewriter(staffController.introduce, 0.03f, delegate
        {

            HandleMoveStaff();
        });
    }



    private void HandleMoveStaff()
    {
        staffController.HandleKillScale();
        StartCoroutine(staffController.HandleStaffMove(false, delegate
        {
          StartCoroutine(  HandleMoveCharector());
        }));
    }   
    
    private IEnumerator HandleMoveCharector()
    {
        yield return new WaitForSeconds(2);
            StartCoroutine(levelData.HandleCharectorMove(true, delegate
            {
                boxChatController.ShowTextTypewriter(levelData.dataCharector.reason, 0.03f, delegate
                {

                    StartCoroutine(MoveCard());
                });

            }));
 
    

    }
    private IEnumerator MoveCard()
    {
         
        yield return cardObj.transform.DOMove(postCardDown.transform.position , 0.75f).WaitForCompletion();



    }




}
