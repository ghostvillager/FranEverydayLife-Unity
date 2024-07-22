using UnityEngine;
using TMPro; // TextMeshProUGUIを使用するため追加
using System;

public class Timetext : MonoBehaviour
{
    // TextMeshProUGUIをドラッグ&ドロップ
    [SerializeField] TextMeshProUGUI DateTimeText;

    // DateTimeを使うための変数を設定
    DateTime TodayNow;

    void Update()
    {
        // 時間を取得
        TodayNow = DateTime.Now;

        // TextMeshProUGUIに年・月・日・秒を表示させる
        DateTimeText.text = TodayNow.Year.ToString() + "年 " + TodayNow.Month.ToString() + "月" + TodayNow.Day.ToString() + "日 " + TodayNow.ToLongTimeString();
    }
}