using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchDetection : MonoBehaviour, IPointerDownHandler
{
    public DarkenLightenImage darkenLightenImage; // DarkenLightenImageスクリプトへの参照
    public GameObject EventTrigerObject;
    public GameObject TextWindowStandard;
    public GameObject BGMObject;
    public EventTriger eventtriger;
    public GameObject SleapEventObject;
    public SleapEvent sleapevent;
    public SoundPlay soundplay;

    public void Start()
    {
        eventtriger = EventTrigerObject.GetComponent<EventTriger>();
        sleapevent = SleapEventObject.GetComponent<SleapEvent>();
        soundplay = BGMObject.GetComponent<SoundPlay>();
    }

    // タッチされたときに呼ばれるメソッド
    public void OnPointerDown(PointerEventData eventData)
    {
        darkenLightenImage.enabled = true;
        darkenLightenImage.darkening = false;
        darkenLightenImage.lightening = true;

        // アタッチされたオブジェクトの名前を取得する
        Debug.Log("アタッチされたオブジェクトの名前: " + this.gameObject.name);

        Invoke("LoadScene", 0.3f); // 2秒後にLoadSceneメソッドを呼び出す
    }

    // 指定したシーンをロードするメソッド
    private void LoadScene()
    {
        string sceneName = "";

        switch (this.gameObject.name)
        {
            case "テキスト(メニュー)":
                break;
            case "テキスト(設定) ":
                sceneName = "設定画面";
                break;
            case "マスク(戻る)":
                sceneName = "基本フランの部屋";
                break;
            case "テキスト(昼寝)":
                break;
            case "テキスト(ゲームをする)":
                sleapevent.sleapeventStop();
                eventtriger.ExitTextWindow();
                soundplay.soundplay("2Dアクション");
                sceneName = "2Dアクション";
                break;
            case "テキスト(やめる)":
                sleapevent.sleapeventStop();
                eventtriger.EventVewer = false;
                break;
        }

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
