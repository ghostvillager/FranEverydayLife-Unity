using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    // `DontDestroyOnLoad` を適用したいゲームオブジェクトのリスト
    public List<GameObject> objectsToPersist = new List<GameObject>();

    void Start()
    {
        // リスト内のすべてのゲームオブジェクトに `DontDestroyOnLoad` を適用
        foreach (GameObject obj in objectsToPersist)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
