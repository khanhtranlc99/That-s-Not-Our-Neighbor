using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using System;
using DG.Tweening;
using UnityEngine.UI;
public enum Difficult
{
    Normal,
    Hard,
    VeryHard,
    Boss

}
public enum KeyType
{
  Id_Name,
  Appearance,
  EntryRequest,
  OnListToDay,

}

public class LevelData : SerializedMonoBehaviour
{
    public DataCharector dataCharector;
    public bool isImporter;
    public Transform postCharector;
    public List<DataCharector> lsDataCharector;
    public PlayerContain playerContain;
    public List<KeyAnswer> lsKeyAnswers;


    public void Init(PlayerContain paramPlayerContain)
    {

        playerContain = paramPlayerContain;

    }

    public IEnumerator HandleCharectorMove(bool moveIn, Action action)
    {
        if (moveIn)
        {
            yield return postCharector.transform.DOMove(playerContain.postMid.position, 1).WaitForCompletion();
        }
        else
        {
            yield return postCharector.transform.DOMove(playerContain.postLeft.position, 1).WaitForCompletion();
        }
        action?.Invoke();
    }





}
[System.Serializable]
public class KeyAnswer
{
    public KeyType keyType;
    public bool correct;
}



[System.Serializable]
public class DataCharector
{
    public Sprite avatar;
    public string name;
    public string lastName;
    public string apartment;
    public string reason;
    public string id;
    public string monthDay;
    
}