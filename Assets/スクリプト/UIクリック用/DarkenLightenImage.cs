using UnityEngine;
using UnityEngine.UI;

public class DarkenLightenImage : MonoBehaviour
{
    public Image image; // 操作するImageコンポーネント

    public float darkenSpeed = 0.5f; // 暗くなる速度
    public float lightenSpeed = 0.5f; // 明るくなる速度

    public bool darkening = true; // 暗くなるかどうかのフラグ
    public bool lightening = false; // 明るくなるかどうかのフラグ
    public string gameObjectName; // アタッチされたオブジェクトの名前

    void Update()
    {
        if (darkening)
        {
            // アルファ値を減少させて暗くする
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0f, darkenSpeed * Time.deltaTime));
        }
        else if (lightening)
        {
            // アルファ値を増加させて明るくする
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0.28f, lightenSpeed * Time.deltaTime));

            // アルファ値が1になったら暗くするフラグを立てる
            if (image.color.a == 0.28f)
            {
                darkening = true;
                lightening = false;
            }
        }
    }
}
