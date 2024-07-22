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
            MenueOpen = !MenueOpen;  // �g�O����Ԃ�؂�ւ���
            MenueObject.SetActive(MenueOpen);  // ���j���[�̕\��/��\����؂�ւ���
        }
    }
}
