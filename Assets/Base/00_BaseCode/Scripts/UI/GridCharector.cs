 
using UnityEngine;
using UnityEngine.UI;

public class GridCharector : MonoBehaviour
{
    public Image thumbnails;
    public Text tvContent;

    public void InitState(DataCharector dataCharector)
    {
        thumbnails.sprite = dataCharector.avatar;
        tvContent.text = dataCharector.name + "\n" + dataCharector.monthDay;
    }
}
