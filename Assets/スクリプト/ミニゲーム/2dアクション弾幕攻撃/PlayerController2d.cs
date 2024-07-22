using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    private Animator animator;
    private float lastMoveDirection = 1f; // 最後に移動した方向、初期値は右向き

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // 移動方向に応じてxパラメータを設定
        if (move != 0)
        {
            // 移動中は移動方向に応じたパラメータを設定
            animator.SetFloat("x", Mathf.Sign(move));
            lastMoveDirection = Mathf.Sign(move); // 最後に移動した方向を更新
        }
        else
        {
            // 停止時は直前の移動方向を保持する
            animator.SetFloat("x", lastMoveDirection);
        }

        // WalkとIdleのboolパラメータを設定
        bool isWalking = Mathf.Abs(move) > 0;
        animator.SetBool("Walk", isWalking);
        animator.SetBool("Idle", !isWalking);

        if (move != 0)
        {
            transform.Translate(Vector2.right * move * Time.deltaTime * 5f);
            // 向きを調整するコードは必要な場合に追加
        }
    }
}