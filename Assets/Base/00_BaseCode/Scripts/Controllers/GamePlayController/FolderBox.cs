using System;
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FolderBox : BaseBox
{
    private static FolderBox instance;
    public static FolderBox Setup( List<DataCharector> dataCharectors , bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<FolderBox>(PathPrefabs.FOLDER_BOX));
            instance.Init(dataCharectors);
        }

        instance.InitState();
        return instance;
    }
    public Button btnClose;
    public Transform postFloor1;
    public Transform postFloor2;
    public Transform postFloor3;
    public Transform postFloor4;
    public GridCharector gridCharector;
    public List<GridCharector> lsgGridCharectors;

    private void Init(List<DataCharector> dataCharectors)
    {
        btnClose.onClick.AddListener(delegate { Close();   });
       for(int i = 0; i < lsgGridCharectors.Count; i ++)
        {
            lsgGridCharectors[i].InitState(dataCharectors[i]);
        }
    }
    private void InitState()
    {


    }
}
