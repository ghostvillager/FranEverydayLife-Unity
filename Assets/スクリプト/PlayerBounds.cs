using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private float minX, maxX, minY, maxY;
    public float extraHorizontalPadding = 1.0f; // �������̒ǉ��̈ړ��͈�
    public float extraVerticalPadding = 1.0f; // �c�����̒ǉ��̈ړ��͈�

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateBounds();
    }

    void Update()
    {
        // ���݂̈ʒu���ړ��͈͂𒴂��Ă���ꍇ�́A��������
        float spriteWidth = spriteRenderer.bounds.size.x / 2;
        float spriteHeight = spriteRenderer.bounds.size.y / 2;

        float clampedX = Mathf.Clamp(transform.position.x, minX + spriteWidth, maxX - spriteWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minY + spriteHeight, maxY - spriteHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void CalculateBounds()
    {
        // �w�i�摜�͈̔͂��擾
        float backgroundWidth = spriteRenderer.bounds.size.x;
        float backgroundHeight = spriteRenderer.bounds.size.y;
        float backgroundLeft = transform.position.x - backgroundWidth / 2;
        float backgroundRight = transform.position.x + backgroundWidth / 2;
        float backgroundBottom = transform.position.y - backgroundHeight / 2;
        float backgroundTop = transform.position.y + backgroundHeight / 2;

        // ��ʂ̍����ƉE��̍��W���擾
        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // �ړ��͈͂�ݒ�
        minX = bottomLeft.x - extraHorizontalPadding;
        maxX = topRight.x + extraHorizontalPadding;
        minY = bottomLeft.y - extraVerticalPadding;
        maxY = topRight.y + extraVerticalPadding;
    }
}