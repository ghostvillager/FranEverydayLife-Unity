using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public GameObject backgroundImage; // 背景画像のオブジェクト
    public float padding = 1.0f; // カメラとプレイヤーの間の余白

    private Camera cam; // カメラコンポーネント
    private SpriteRenderer backgroundRenderer; // 背景画像の SpriteRenderer コンポーネント
    private float minX, maxX, minY, maxY; // 移動制限の範囲

    void Start()
    {
        // カメラと背景画像のコンポーネントを取得
        cam = GetComponent<Camera>();
        backgroundRenderer = backgroundImage.GetComponent<SpriteRenderer>();

        // 移動制限の範囲を計算
        CalculateBounds();
    }

    void Update()
    {
        // プレイヤーの位置を取得し、移動制限の範囲内に制限してカメラを移動
        Vector3 playerPos = player.transform.position;
        float clampedX = Mathf.Clamp(playerPos.x, minX + cam.orthographicSize * cam.aspect, maxX - cam.orthographicSize * cam.aspect);
        float clampedY = Mathf.Clamp(playerPos.y, minY + cam.orthographicSize, maxY - cam.orthographicSize);
        transform.position = new Vector3(clampedX, clampedY, -10);
    }

    void CalculateBounds()
    {
        // カメラのビューポート座標をワールド座標に変換して、画面の左下と右上の座標を取得
        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // 背景画像の範囲を取得
        float backgroundWidth = backgroundRenderer.bounds.size.x;
        float backgroundHeight = backgroundRenderer.bounds.size.y;
        float backgroundLeft = backgroundImage.transform.position.x - backgroundWidth / 2;
        float backgroundRight = backgroundImage.transform.position.x + backgroundWidth / 2;
        float backgroundBottom = backgroundImage.transform.position.y - backgroundHeight / 2;
        float backgroundTop = backgroundImage.transform.position.y + backgroundHeight / 2;

        // カメラの移動制限を背景画像の範囲内に制限
        minX = backgroundLeft + padding;
        maxX = backgroundRight - padding;
        minY = backgroundBottom + padding;
        maxY = backgroundTop - padding;
    }
}