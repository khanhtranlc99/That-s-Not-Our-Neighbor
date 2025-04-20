using System;
using UnityEngine.UI;
using UnityEngine;

public class CardInfoBox : BaseBox
{
    private static CardInfoBox instance;
    public static CardInfoBox Setup(DataCharector dataCharectors, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<CardInfoBox>(PathPrefabs.CARD_INFO_BOX));
            instance.Init(dataCharectors);
        }

        instance.InitState();
        return instance;
    }
    public Button btnClose;
    public Image thumnails;
    public Text tvName;
    public Text tvLastName;
    public Text tvId;
    public Text tvReason;
    private void Init(DataCharector dataCharectors)
    {
        btnClose.onClick.AddListener(delegate { Close();  });
        thumnails.sprite = dataCharectors.avatar;
        tvName.text = "Name:" + "\n" + dataCharectors.name;
        tvLastName.text = "Last Name:" + "\n" + dataCharectors.lastName;
        tvReason.text = "Reason:" +"\n" + dataCharectors.reason;
        tvId.text = "ID:" + dataCharectors.id;

    }
    private void InitState()
    {

    }
}
