using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoseBox : BaseBox
{
    public static LoseBox _instance;
    public static LoseBox Setup(bool isAnim)
    {
        if (_instance == null)
        {
            _instance = Instantiate(Resources.Load<LoseBox>(PathPrefabs.LOSE_BOX));
            _instance.Init( isAnim);
        }
        _instance.InitState();
        return _instance;
    }

    public Text tvScore;
    public Button btnRetry;
    public Button btnSkip;

    public Transform post_1;
    public Transform post_2;

    public Transform hand_1;
    public Transform hand_2;

    public GameObject blood_1;
    public GameObject blood_2;

    public void Init(bool isAnim)
    {
       if(isAnim)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(hand_1.transform.DOMove(post_1.position, 0.5f)) ;
            sequence.Append(hand_2.transform.DOMove(post_2.position, 0.5f));
            sequence.OnComplete(delegate
            {
                blood_1.SetActive(true);
                blood_2.SetActive(true);
            });
        }
        btnSkip.onClick.AddListener(delegate { HandleSkip();  });
        btnRetry.onClick.AddListener(delegate { HandleRetry();  });
    }   
    public void InitState()
    {
        GameController.Instance.AnalyticsController.LoseLevel(UseProfile.CurrentLevel);
        tvScore.text = GamePlayController.Instance.playerContain.answerController.HandleCheckCount + "/4";
    }
    public void HandleRetry()
    {
        GameController.Instance.musicManager.PlayClickSound();

        GameController.Instance.admobAds.ShowInterstitial(false, actionIniterClose: () => { Next(); }, actionWatchLog: "InterWinBox");

        void Next()
        {    
            Initiate.Fade("GamePlay", Color.black, 2f);
        }
      
    }
   
    public void HandleSkip()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowVideoReward(
               actionReward: () =>
               {

                   UseProfile.CurrentLevel += 1;
                   Initiate.Fade("GamePlay", Color.black, 2f);

               },
               actionNotLoadedVideo: () =>
               {
                   btnSkip.transform.SetAsLastSibling();
                   GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp_UI
                    (
                       btnSkip.transform
                       ,
                    btnSkip.transform.position,
                    "No video",
                    Color.white,
                    isSpawnItemPlayer: true
                    );
               },
               actionClose: null,
               ActionWatchVideo.Skip_level,
               UseProfile.CurrentLevel.ToString());

      

    }

}
