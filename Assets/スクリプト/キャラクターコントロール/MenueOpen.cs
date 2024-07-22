using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menue : MonoBehaviour
{
    public GameObject MenueObject;
    private bool MenueOpen = false;

    void Start()
    {
        MenueObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            MenueOpen = !MenueOpen;  // トグル状態を切り替える
            MenueObject.SetActive(MenueOpen);  // メニューの表示/非表示を切り替える
        }
    }
}
