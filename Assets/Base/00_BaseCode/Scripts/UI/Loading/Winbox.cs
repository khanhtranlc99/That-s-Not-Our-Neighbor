using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Winbox : BaseBox
{
    public static Winbox _instance;
    public static Winbox Setup()
    {
        if (_instance == null)
        {
            _instance = Instantiate(Resources.Load<Winbox>(PathPrefabs.WIN_BOX));
            _instance.Init();
        }
        _instance.InitState();
        return _instance;
    }

    public Button nextButton;
 
  
    
    public void Init()
    {
        nextButton.onClick.AddListener(delegate { HandleNext();});
        
        GameController.Instance.musicManager.PlayWinSound();
    }   
    public void InitState()
    {

        GameController.Instance.AnalyticsController.WinLevel(UseProfile.CurrentLevel);

     
    }    
    private void HandleNext()
    {
        GameController.Instance.musicManager.PlayClickSound();
        UseProfile.CurrentLevel += 1;
        if (UseProfile.CurrentLevel >= 6)
        {
            UseProfile.CurrentLevel = 6;
        }


        GameController.Instance.admobAds.ShowInterstitial(false, actionIniterClose: () => { Next(); }, actionWatchLog: "InterWinBox");
        void Next()
        {
   
            Close();
            Initiate.Fade("GamePlay", Color.black, 2f);

        }
    }
 
    private void OnDestroy()
    {
        
    }
}
