using TMPro;
using UnityEngine;

public class TextPlayEvent : MonoBehaviour
{
    public GameObject TextWindowEvent;
    public GameObject SystemLogText;
    public TextMeshProUGUI SystemLogTextMesh;

    void Start()
    {
        TextWindowEvent = FindInactiveObjectByName("会話枠 (イベント用)");
        SystemLogText = FindInactiveObjectByName("システムログ(イベント用)");

        if (TextWindowEvent == null)
        {
            Debug.LogError("会話枠 (イベント用)が見つかりません。");
        }

        // システムログにアタッチされているTextMeshProUGUIを取得
        if (SystemLogText != null)
        {
            SystemLogTextMesh = SystemLogText.GetComponent<TextMeshProUGUI>();
            if (SystemLogTextMesh == null)
            {
                Debug.LogWarning("システムログにTextMeshProUGUIがアタッチされていません。");
            }
        }
        else
        {
            Debug.LogError("システムログ(イベント用)が見つかりません。");
        }

        // 初期状態で非表示にする
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
            Debug.Log("プレイヤーと接触しました。");
            if (TextWindowEvent != null)
            {
                TextWindowEvent.SetActive(true);
                if (SystemLogTextMesh != null)
                {
                    SystemLogTextMesh.gameObject.SetActive(true);
                    SystemLogTextMesh.text = "ここから先へは行けません。"; // システムログにテキストを設定する例
                }
                else
                {
                    Debug.LogError("SystemLogTextMeshがnullです。");
                }
            }
            else
            {
                Debug.LogError("TextWindowEventがnullです。");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーから離れました。");
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