using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public List<KeyAnswer> lsKeyAnswers;

    public KeyAnswer GetKeyAnswer(KeyType param)
    {
        foreach (var keyAnswer in lsKeyAnswers)
        {
            if (keyAnswer.keyType == param)
            {
                return keyAnswer;
            }
        }
        return null;
    }    

    public bool HandleCheckWinLose
    {
        get
        {
            var temp = true;
            for(int i = 0; i < lsKeyAnswers.Count; i ++)
            {
                if (lsKeyAnswers[i].correct != GamePlayController.Instance.playerContain.levelData.lsKeyAnswers[i].correct)
                {
                    temp = false;
                    break;
                }
            }
            return temp;
        }
    }

    public int HandleCheckCount
    {
        get
        {
            var temp = 0;
            for (int i = 0; i < lsKeyAnswers.Count; i++)
            {
                if (lsKeyAnswers[i].correct == GamePlayController.Instance.playerContain.levelData.lsKeyAnswers[i].correct)
                {
                    temp ++;
                }
            }
            return temp;
        }
    }


}
