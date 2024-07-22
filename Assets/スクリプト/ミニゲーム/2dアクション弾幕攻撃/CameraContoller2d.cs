using UnityEngine;

public class SmoothFollowCamera2D : MonoBehaviour
{
    public Transform target; // �ǐՑΏۂ�Transform�i�v���C���[�Ȃǁj
    public float smoothTime = 0.3f; // �ړ��̊��炩���𒲐����邽�߂̃p�����[�^

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
            // �ǐՑΏۂ̈ʒu���擾
            Vector3 targetPosition = target.position;

            // �J�����̌��݈ʒu���擾
            Vector3 currentPosition = transform.position;

            // �ڕW�ʒu�Ɍ������Ċ��炩�Ɉړ�����
            Vector3 smoothPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);

            // �J������Z���W���Œ肵�āA2D��Ԃł݈̂ړ�����
            smoothPosition.z = transform.position.z;

            // �J������ڕW�ʒu�Ɉړ�������
            transform.position = smoothPosition;
        }
    }
}