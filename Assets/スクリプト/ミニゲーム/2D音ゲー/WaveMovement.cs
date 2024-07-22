using System.Collections;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float waveDuration = 1.0f; // 波打つ時間
    public float waveHeight = 0.5f; // 波の高さ（スケールの変化幅）
    public float waveFrequency = 1.0f; // 波の周波数

    private Vector3 startScale;
    private bool isAnimating = true;

    void Start()
    {
        startScale = transform.localScale; // 初期スケールを保存
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ウェーブ開始！！");
            StartCoroutine(AnimateWave());
        }
    }

        private IEnumerator AnimateWave()
    {
        float elapsedTime = 0f;

        while (elapsedTime < waveDuration)
        {
            // 時間に基づいて波の高さ（スケール）を計算
            float scaleOffset = Mathf.Sin(elapsedTime * waveFrequency * Mathf.PI) * waveHeight;

            // 新しいスケールを設定（Y軸のスケールを波打たせる）
            transform.localScale = new Vector3(startScale.x, startScale.y + scaleOffset, startScale.z);

            // 経過時間を更新
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // アニメーション終了時にスケールを初期値に戻す
        transform.localScale = startScale;
        isAnimating = false;
    }
}