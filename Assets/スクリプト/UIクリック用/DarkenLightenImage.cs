using UnityEngine;
using UnityEngine.UI;

public class DarkenLightenImage : MonoBehaviour
{
    public Image image; // ���삷��Image�R���|�[�l���g

    public float darkenSpeed = 0.5f; // �Â��Ȃ鑬�x
    public float lightenSpeed = 0.5f; // ���邭�Ȃ鑬�x

    public bool darkening = true; // �Â��Ȃ邩�ǂ����̃t���O
    public bool lightening = false; // ���邭�Ȃ邩�ǂ����̃t���O
    public string gameObjectName; // �A�^�b�`���ꂽ�I�u�W�F�N�g�̖��O

    void Update()
    {
        if (darkening)
        {
            // �A���t�@�l�����������ĈÂ�����
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0f, darkenSpeed * Time.deltaTime));
        }
        else if (lightening)
        {
            // �A���t�@�l�𑝉������Ė��邭����
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0.28f, lightenSpeed * Time.deltaTime));

            // �A���t�@�l��1�ɂȂ�����Â�����t���O�𗧂Ă�
            if (image.color.a == 0.28f)
            {
                darkening = true;
                lightening = false;
            }
        }
    }
}
