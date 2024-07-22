using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProの名前空間をインポート

public class EventCS : MonoBehaviour
{
    private SleapEvent sleapEvent;
    private EventTriger eventTriger;
    public GameObject TextWindowEvent;
    public GameObject Fran;
    public GameObject SpriteNull;
    public TextAsset SleapEventAsset;
    public TextMeshProUGUI SleapText;

    private void Start()
    {
        // 初期化処理
        sleapEvent = this.GetComponent<SleapEvent>();
        eventTriger = Fran.GetComponent<EventTriger>();
    }

    public void EventStart(string eventName)
    {
        if (eventName == "SoffaEvent")
        {
            Debug.Log("イベントCSのソファーイベント開始");
            eventTriger.textWindow.gameObject.SetActive(false);
            eventTriger.FranSprite.gameObject.SetActive(false);
            eventTriger.Text.gameObject.SetActive(false);
            eventTriger.CharactorText.gameObject.SetActive(false);
            eventTriger.textWindow = TextWindowEvent;
            eventTriger.splitText1 = SleapEventAsset.text.Split('\n');
            eventTriger.Text = SleapText;
            eventTriger.textNum1 = 0;
            eventTriger.FranSprite = SpriteNull;
            eventTriger.EventSpaceTriger = true;
            Debug.Log("textNum = " + eventTriger.textNum1);
            eventTriger.EnterCheck = 0;
            sleapEvent.sleapevent();
        }
        else
        {
            eventTriger.ChooseExit = true;
        }
    }
}
