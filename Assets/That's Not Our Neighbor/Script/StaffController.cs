using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    public GameObject staff;
    public PlayerContain playerContain;
    public Vector3 lcScale;
    public string introduce;
    public string arrest;


    public void Init()
    {
        lcScale = staff.transform.localScale;       
        SetPostMid();
    }
    
    public IEnumerator HandleStaffMove(bool moveIn, Action action)
    {
        if(moveIn)
        {
           yield return staff.transform.DOMove(playerContain.postMid.position,0.5f).WaitForCompletion();
        }
        else
        {
           yield return staff.transform.DOMove(playerContain.postLeft.position, 1).WaitForCompletion();
        }
        action?.Invoke();
    }
    public void SetPostMid()
    {
        staff.transform.position = playerContain.postMid.position;
    }

    public void HandelScaleInOut()
    {
        staff.transform.DOScale(new Vector3(lcScale.x +0.1f, lcScale.y + 0.1f, lcScale.z + 0.1f), 0.5f).OnComplete(delegate
        {
            staff.transform.DOScale(new Vector3(lcScale.x , lcScale.y , lcScale.z), 0.5f).OnComplete(delegate
            {
                HandelScaleInOut();
            });
        });
    }

    public void HandleKillScale()
    {
        staff.transform.DOKill();
    }    




   
  
}
