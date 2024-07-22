using TMPro;
using UnityEngine;

public class TextPlayEvent : MonoBehaviour
{
    public GameObject TextWindowEvent;
    public GameObject SystemLogText;
    public TextMeshProUGUI SystemLogTextMesh;

    void Start()
    {
        TextWindowEvent = FindInactiveObjectByName("��b�g (�C�x���g�p)");
        SystemLogText = FindInactiveObjectByName("�V�X�e�����O(�C�x���g�p)");

        if (TextWindowEvent == null)
        {
            Debug.LogError("��b�g (�C�x���g�p)��������܂���B");
        }

        // �V�X�e�����O�ɃA�^�b�`����Ă���TextMeshProUGUI���擾
        if (SystemLogText != null)
        {
            SystemLogTextMesh = SystemLogText.GetComponent<TextMeshProUGUI>();
            if (SystemLogTextMesh == null)
            {
                Debug.LogWarning("�V�X�e�����O��TextMeshProUGUI���A�^�b�`����Ă��܂���B");
            }
        }
        else
        {
            Debug.LogError("�V�X�e�����O(�C�x���g�p)��������܂���B");
        }

        // ������ԂŔ�\���ɂ���
        if (TextWindowEvent != null)
        {
            TextWindowEvent.SetActive(false);
        }

        if (SystemLogText != null)
        {
            SystemLogText.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�v���C���[�ƐڐG���܂����B");
            if (TextWindowEvent != null)
            {
                TextWindowEvent.SetActive(true);
                if (SystemLogTextMesh != null)
                {
                    SystemLogTextMesh.gameObject.SetActive(true);
                    SystemLogTextMesh.text = "���������ւ͍s���܂���B"; // �V�X�e�����O�Ƀe�L�X�g��ݒ肷���
                }
                else
                {
                    Debug.LogError("SystemLogTextMesh��null�ł��B");
                }
            }
            else
            {
                Debug.LogError("TextWindowEvent��null�ł��B");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�v���C���[���痣��܂����B");
            if (TextWindowEvent != null)
            {
                TextWindowEvent.SetActive(false);
            }

            if (SystemLogTextMesh != null)
            {
                SystemLogTextMesh.gameObject.SetActive(false);
            }
        }
    }

    GameObject FindInactiveObjectByName(string name)
    {
        Transform[] allTransforms = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.hideFlags == HideFlags.None && t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}