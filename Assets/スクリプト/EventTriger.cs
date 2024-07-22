using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class EventTriger : MonoBehaviour
{
    private Animator TriangleYokoAnimator;
    private Animator animator;
    public GameObject EventCSObject;
    private EventCS eventCS;
    private string functionName;

    public GameObject textWindow; // バッキングフィールド

    public bool EventVewer = false;
    public bool TextNumEventTriger = false;
    public GameObject TextWindowStandard;
    public GameObject TextWindowEvent;
    public GameObject TriangleYoko;
    public GameObject Player;
    public GameObject FranSprite;
    public GameObject FranBeforSleep;
    public GameObject FranSoffa;
    public GameObject FranStandard;
    public TextMeshProUGUI CharactorText;
    public int EnterCheck;
    public int ChooseAreaCheck;
    public string CheckIconArea = "Left";
    public bool ChooseExit = false;
    public bool EventSpaceTriger;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI StandardText;
    public GameObject ChooseTextObject;
    public TextMeshProUGUI ChooseText1;
    public TextMeshProUGUI ChooseText2;
    public TextMeshProUGUI ChooseText3;
    public TextMeshProUGUI ChooseText4;
    [SerializeField]
    public TextAsset SleapAsset;
    public TextAsset SitAsset;
    public TextAsset TeaTimeAsset;
    public TextAsset ChangeClothesAsset;
    public string[] splitText1;
    public string[] splitText2;
    private string loadText;
    public int textNum1;
    public static bool EventCheck = false;

    private void Start()
    {
        FranSprite = FranStandard;
        textWindow = TextWindowStandard;
        animator = GetComponent<Animator>();

        if (EventCSObject != null)
        {
            eventCS = EventCSObject.GetComponent<EventCS>();
            if (eventCS == null)
            {
                Debug.LogWarning("EventCS component not found on EventCSObject.");
            }
        }
        else
        {
            Debug.LogWarning("EventCSObject is not assigned.");
        }
    }

    public void ExitTextWindow()
    {
        MonoBehaviour[] scripts = Player.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            script.enabled = true;
        }
        ChooseExit = false;
        EventCheck = false;
        ChooseTextObject.SetActive(false);
        textWindow.gameObject.SetActive(false);
        textNum1 = 0;
        EnterCheck = 1;
        FranSprite.gameObject.SetActive(false);
        Text.gameObject.SetActive(false);
        TriangleYoko.gameObject.SetActive(false);
        CharactorText.gameObject.SetActive(false);
        textWindow = TextWindowStandard;
        TextNumEventTriger = false;
        Text = StandardText;
        ChooseText1.gameObject.SetActive(false);
        ChooseText2.gameObject.SetActive(false);
        ChooseText3.gameObject.SetActive(false);
        ChooseText4.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        FranSprite = FranStandard;
        // 特定の部分に当たったときの処理
        if (collision.gameObject.CompareTag("睡眠イベント"))
        {
            loadText = SleapAsset.text;
            functionName = "SleapEvent";
            FranSprite = FranBeforSleep;
            Debug.Log("睡眠ベント開始");
        }
        else if (collision.gameObject.CompareTag("ソファーイベント"))
        {
            loadText = SitAsset.text;
            functionName = "SoffaEvent";
            Debug.Log("ソファーイベント開始");
        }
        else if (collision.gameObject.CompareTag("お茶イベント"))
        {
            loadText = TeaTimeAsset.text;
            functionName = "TeaEvent";
            Debug.Log("お茶イベント開始");
        }
        else if (collision.gameObject.CompareTag("着替えイベント"))
        {
            loadText = ChangeClothesAsset.text;
            functionName = "ChangeClothesEvent";
            Debug.Log("着替えイベント開始");
        }

        animator.SetBool("Walk", false);
        animator.SetBool("Idle", true);
        splitText1 = loadText.Split('\n');
        textNum1 = 0;
        TriangleYokoAnimator = TriangleYoko.GetComponent<Animator>();
        EventCheck = true;
        MonoBehaviour[] scripts = Player.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script.GetType().Name == "CharcotorController")
            {
                script.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (textNum1 < splitText1.Length && !ChooseExit && EventCheck)
        {
            TriangleYoko.gameObject.SetActive(false);
            Vector3 TY = TriangleYoko.transform.position;
            CharactorText.text = "フランドール";
            // 前のテキストを消去して新しいテキストを表示
            Text.text = splitText1[textNum1];
            textWindow.gameObject.SetActive(true);
            FranSprite.gameObject.SetActive(true);
            CharactorText.gameObject.SetActive(true);
            Text.gameObject.SetActive(true);

            if (splitText1[textNum1].Contains("□"))
            {
                EventVewer = true;
                Text.gameObject.SetActive(false);
                ChooseTextObject.SetActive(true);
                splitText2 = splitText1[textNum1].Split("□");
                for (int i = 0; i < splitText2.Length; i++)
                {
                    switch (i)
                    {
                        case 1:
                            ChooseText1.gameObject.SetActive(true);
                            ChooseText1.text = splitText2[i];
                            break;
                        case 2:
                            ChooseText2.gameObject.SetActive(true);
                            ChooseText2.text = splitText2[i];
                            break;
                        case 3:
                            ChooseText3.gameObject.SetActive(true);
                            ChooseText3.text = splitText2[i];
                            break;
                        case 4:
                            ChooseText4.gameObject.SetActive(true);
                            ChooseText4.text = splitText2[i];
                            break;
                    }
                }
                TextNumEventTriger = true;
            }

                if (splitText1[textNum1].Contains("はい"))
            {
                TriangleYoko.gameObject.SetActive(true);
                if (CheckIconArea == "Left")
                {
                    TriangleYoko.transform.position = new Vector3(Text.gameObject.transform.position.x + 0 * splitText1[textNum1].Length, Text.gameObject.transform.position.y - 65, TY.z);
                    if (Input.GetKeyDown("space"))
                    {
                        eventCS.EventStart(functionName);
                    }
                }
                else
                {
                    TriangleYoko.transform.position = new Vector3(Text.gameObject.transform.position.x + 18 * splitText1[textNum1].Length, Text.gameObject.transform.position.y - 65, TY.z);
                    if (Input.GetKeyDown("space"))
                    {
                        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 2, Player.transform.position.z);
                        ChooseExit = true;
                    }
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    CheckIconArea = "Right";
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    CheckIconArea = "Left";
                }
                ChooseAreaCheck = 1;
            }

            if (Input.GetKeyDown("space"))
            {
                if (EnterCheck == 1)
                {
                    Text.text = "";
                    textNum1++;
                    EnterCheck = 0;
                }
                else if (EventSpaceTriger)
                {
                    EventSpaceTriger = false;
                }
                else
                {
                    Debug.Log("会話" + textNum1);
                    textNum1++;
                }
            }

            if (TextNumEventTriger)
            {
                textNum1++;
            }
        }
        else
        {
            if (!EventVewer)
            {
                ExitTextWindow();
            }
        }
    }
}