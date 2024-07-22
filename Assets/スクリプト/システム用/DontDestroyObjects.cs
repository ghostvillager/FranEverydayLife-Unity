using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    // `DontDestroyOnLoad` ��K�p�������Q�[���I�u�W�F�N�g�̃��X�g
    public List<GameObject> objectsToPersist = new List<GameObject>();

    void Start()
    {
        // ���X�g���̂��ׂẴQ�[���I�u�W�F�N�g�� `DontDestroyOnLoad` ��K�p
        foreach (GameObject obj in objectsToPersist)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
