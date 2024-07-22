using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; // TextMeshProの名前空間をインポート

public class SleapEvent : MonoBehaviour
{
    public GameObject EventSpriteSleap;
    public void sleapevent()
    {
        EventSpriteSleap.SetActive(true);
    }

    public void sleapeventStop()
    {
        EventSpriteSleap.SetActive(false);
    }
}