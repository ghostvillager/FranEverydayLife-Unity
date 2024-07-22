using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    private Animator animator;
    private float lastMoveDirection = 1f; // �Ō�Ɉړ����������A�����l�͉E����

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // �ړ������ɉ�����x�p�����[�^��ݒ�
        if (move != 0)
        {
            // �ړ����͈ړ������ɉ������p�����[�^��ݒ�
            animator.SetFloat("x", Mathf.Sign(move));
            lastMoveDirection = Mathf.Sign(move); // �Ō�Ɉړ������������X�V
        }
        else
        {
            // ��~���͒��O�̈ړ�������ێ�����
            animator.SetFloat("x", lastMoveDirection);
        }

        // Walk��Idle��bool�p�����[�^��ݒ�
        bool isWalking = Mathf.Abs(move) > 0;
        animator.SetBool("Walk", isWalking);
        animator.SetBool("Idle", !isWalking);

        if (move != 0)
        {
            transform.Translate(Vector2.right * move * Time.deltaTime * 5f);
            // �����𒲐�����R�[�h�͕K�v�ȏꍇ�ɒǉ�
        }
    }
}