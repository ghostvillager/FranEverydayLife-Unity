using UnityEngine;

public class SmoothFollowCamera2D : MonoBehaviour
{
    public Transform target; // 追跡対象のTransform（プレイヤーなど）
    public float smoothTime = 0.3f; // 移動の滑らかさを調整するためのパラメータ

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // 追跡対象の位置を取得
            Vector3 targetPosition = target.position;

            // カメラの現在位置を取得
            Vector3 currentPosition = transform.position;

            // 目標位置に向かって滑らかに移動する
            Vector3 smoothPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);

            // カメラのZ座標を固定して、2D空間でのみ移動する
            smoothPosition.z = transform.position.z;

            // カメラを目標位置に移動させる
            transform.position = smoothPosition;
        }
    }
}