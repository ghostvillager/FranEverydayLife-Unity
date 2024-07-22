using UnityEngine;
using TMPro; // TextMeshProUGUI���g�p���邽�ߒǉ�
using System;

public class Timetext : MonoBehaviour
{
    // TextMeshProUGUI���h���b�O&�h���b�v
    [SerializeField] TextMeshProUGUI DateTimeText;

    // DateTime���g�����߂̕ϐ���ݒ�
    DateTime TodayNow;

    void Update()
    {
        // ���Ԃ��擾
        TodayNow = DateTime.Now;

        // TextMeshProUGUI�ɔN�E���E���E�b��\��������
        DateTimeText.text = TodayNow.Year.ToString() + "�N " + TodayNow.Month.ToString() + "��" + TodayNow.Day.ToString() + "�� " + TodayNow.ToLongTimeString();
    }
}