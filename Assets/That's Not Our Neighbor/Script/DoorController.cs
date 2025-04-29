using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;
 
public class DoorController : MonoBehaviour
{
    public Transform postUp;
    public Transform postDown;
    public Transform door;
 
    public Sprite open;
    public Sprite close;
    public SpriteRenderer spriteRenderer;

    public ObjInGame objOpen;
    public ObjInGame objClose;
    public ObjInGame objPaper;

    public Image warningVfx;
    public PlayerContain playerContain;

    

    public void Init()
    {
       
    }
    public void HandleBtnCloseDoor()
    {

        if (playerContain.completeChoose)
        {
            warningVfx.gameObject.SetActive(true);
            HandleTweenWarning();
            StartCoroutine(HandleMoveDoor(false, delegate {
                HandleKillCharector();
            }));
           
        }
        else
        {
            GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp
                (
                objClose.transform.position,
                "Documents first!"  ,
                Color.white,
                isSpawnItemPlayer: true
                );
            objPaper.HandleScale();
        }


    }
    public void HandleBtnOpenDoor()
    {
        if(playerContain.completeChoose)
        {
            StartCoroutine(playerContain.levelData.HandleCharectorMove(false, delegate {

                StartCoroutine(EndGameCharector());
            }));
            spriteRenderer.sprite = close;            
        }
        else
        {
            GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp
                    (
                    objOpen.transform.position,
                    "Documents first!",
                    Color.white,
                    isSpawnItemPlayer: true
                    );
            objPaper.HandleScale();
        }
    
    }



    public IEnumerator HandleMoveDoor(bool isUp, Action callback)
    {
        if(isUp)
        {
            yield return door.transform.DOMoveY(postUp.position.y, 0.75f).WaitForCompletion();
        }
        else
        {
            yield return door.transform.DOMoveY(postDown.position.y, 0.75f).WaitForCompletion();
        }
        callback?.Invoke();
    }

    public void HandleTweenWarning()
    {
        warningVfx.DOFade(1, 0.5f).OnComplete(delegate
        {
            warningVfx.DOFade(0, 0.5f).OnComplete(delegate
            {
                HandleTweenWarning();
            });
        });
    }    

    public void HandleKillCharector()
    {

        StartCoroutine(IeKillCharector());

    }    

    private IEnumerator IeKillCharector()
    {
        yield return new WaitForSeconds(2);
        playerContain.levelData.postCharector.gameObject.SetActive(false);
        playerContain.staffController.SetPostMid();
        StartCoroutine(HandleMoveDoor(true, delegate {
            warningVfx.DOKill();
            warningVfx.color = new Color32(0,0,0,0);
            playerContain.boxChatController.ShowTextTypewriter(playerContain.staffController.arrest, 0.03f, delegate
            {
               StartCoroutine(HandleMoveStaffEndGame()) ;
            });
        }));
    }


    private IEnumerator HandleMoveStaffEndGame()
    {
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(playerContain.staffController.HandleStaffMove(false, delegate {  }));
        yield return new WaitForSeconds(1);

        GameController.Instance.admobAds.HandleShowMerec();
        if (playerContain.levelData.isImporter)
        {
            Winbox.Setup().Show();
        }
        else
        {
            LoseBox.Setup(false).Show();
        }
    }

    private IEnumerator EndGameCharector()
    {
        yield return new WaitForSeconds(1);
        GameController.Instance.admobAds.HandleShowMerec();
        if (!playerContain.levelData.isImporter)
        {
            Winbox.Setup().Show();
        }
        else
        {
            LoseBox.Setup(true).Show();
        }
        
      

    }
}
