using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private float minX, maxX, minY, maxY;
    public float extraHorizontalPadding = 1.0f; // 横方向の追加の移動範囲
    public float extraVerticalPadding = 1.0f; // 縦方向の追加の移動範囲

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateBounds();
    }

    void Update()
    {
        // 現在の位置が移動範囲を超えている場合は、制限する
        float spriteWidth = spriteRenderer.bounds.size.x / 2;
        float spriteHeight = spriteRenderer.bounds.size.y / 2;

        float clampedX = Mathf.Clamp(transform.position.x, minX + spriteWidth, maxX - spriteWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minY + spriteHeight, maxY - spriteHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void CalculateBounds()
    {
        // 背景画像の範囲を取得
        float backgroundWidth = spriteRenderer.bounds.size.x;
        float backgroundHeight = spriteRenderer.bounds.size.y;
        float backgroundLeft = transform.position.x - backgroundWidth / 2;
        float backgroundRight = transform.position.x + backgroundWidth / 2;
        float backgroundBottom = transform.position.y - backgroundHeight / 2;
        float backgroundTop = transform.position.y + backgroundHeight / 2;

        // 画面の左下と右上の座標を取得
        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // 移動範囲を設定
        minX = bottomLeft.x - extraHorizontalPadding;
        maxX = topRight.x + extraHorizontalPadding;
        minY = bottomLeft.y - extraVerticalPadding;
        maxY = topRight.y + extraVerticalPadding;
    }
}