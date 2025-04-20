using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class TodayListBox : BaseBox
{
    private static TodayListBox instance;
    public static TodayListBox Setup(List<DataCharector> dataCharectors, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<TodayListBox>(PathPrefabs.TO_DAY_LIST_BOX));
            instance.Init(dataCharectors);
        }

        instance.InitState();
        return instance;
    }

    public Button btnClose;
    public Transform postCharector;
    public GridCharector gridCharector;

    private void Init(List<DataCharector> dataCharectors)
    {
        btnClose.onClick.AddListener(delegate { Close(); });
        foreach (var item in dataCharectors)
        {
            var temp = SimplePool2.Spawn(gridCharector);
            temp.transform.SetParent(postCharector, false);
            temp.InitState(item);
        }
    }
    private void InitState()
    {
       
    }
}
