using System.Collections;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float waveDuration = 1.0f; // �g�ł���
    public float waveHeight = 0.5f; // �g�̍����i�X�P�[���̕ω����j
    public float waveFrequency = 1.0f; // �g�̎��g��

    private Vector3 startScale;
    private bool isAnimating = true;

    void Start()
    {
        startScale = transform.localScale; // �����X�P�[����ۑ�
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�E�F�[�u�J�n�I�I");
            StartCoroutine(AnimateWave());
        }
    }

        private IEnumerator AnimateWave()
    {
        float elapsedTime = 0f;

        while (elapsedTime < waveDuration)
        {
            // ���ԂɊ�Â��Ĕg�̍����i�X�P�[���j���v�Z
            float scaleOffset = Mathf.Sin(elapsedTime * waveFrequency * Mathf.PI) * waveHeight;

            // �V�����X�P�[����ݒ�iY���̃X�P�[����g�ł�����j
            transform.localScale = new Vector3(startScale.x, startScale.y + scaleOffset, startScale.z);

            // �o�ߎ��Ԃ��X�V
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �A�j���[�V�����I�����ɃX�P�[���������l�ɖ߂�
        transform.localScale = startScale;
        isAnimating = false;
    }
}