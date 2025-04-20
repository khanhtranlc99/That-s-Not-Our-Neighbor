using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListBox : BaseBox
{
    private static CheckListBox instance;
    public static CheckListBox Setup( DataCharector  dataCharectors, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<CheckListBox>(PathPrefabs.CHECK_LIST_BOX));
            instance.Init(dataCharectors);
        }

        instance.InitState();
        return instance;
    }
    public Button btnClose;
    public List<CheckListChoose> lsCheckListChooses;
    public bool AllCheckOk
    {
        get
        {
            var temp = true;
            foreach(var item in lsCheckListChooses)
            {
                if(!item.isCheck)
                {
                    temp = false; 
                }
            }
            return temp;
        }
    }



    private void Init(DataCharector dataCharectors)
    {
        btnClose.onClick.AddListener(delegate { Close();  });
        foreach(var item in lsCheckListChooses)
        {
            item.Init();
        }
    }
    private void InitState()
    {

    }

}
