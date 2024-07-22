using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchDetection : MonoBehaviour, IPointerDownHandler
{
    public DarkenLightenImage darkenLightenImage; // DarkenLightenImage�X�N���v�g�ւ̎Q��
    public GameObject EventTrigerObject;
    public GameObject TextWindowStandard;
    public GameObject BGMObject;
    public EventTriger eventtriger;
    public GameObject SleapEventObject;
    public SleapEvent sleapevent;
    public SoundPlay soundplay;

    public void Start()
    {
        eventtriger = EventTrigerObject.GetComponent<EventTriger>();
        sleapevent = SleapEventObject.GetComponent<SleapEvent>();
        soundplay = BGMObject.GetComponent<SoundPlay>();
    }

    // �^�b�`���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void OnPointerDown(PointerEventData eventData)
    {
        darkenLightenImage.enabled = true;
        darkenLightenImage.darkening = false;
        darkenLightenImage.lightening = true;

        // �A�^�b�`���ꂽ�I�u�W�F�N�g�̖��O���擾����
        Debug.Log("�A�^�b�`���ꂽ�I�u�W�F�N�g�̖��O: " + this.gameObject.name);

        Invoke("LoadScene", 0.3f); // 2�b���LoadScene���\�b�h���Ăяo��
    }

    // �w�肵���V�[�������[�h���郁�\�b�h
    private void LoadScene()
    {
        string sceneName = "";

        switch (this.gameObject.name)
        {
            case "�e�L�X�g(���j���[)":
                break;
            case "�e�L�X�g(�ݒ�) ":
                sceneName = "�ݒ���";
                break;
            case "�}�X�N(�߂�)":
                sceneName = "��{�t�����̕���";
                break;
            case "�e�L�X�g(���Q)":
                break;
            case "�e�L�X�g(�Q�[��������)":
                sleapevent.sleapeventStop();
                eventtriger.ExitTextWindow();
                soundplay.soundplay("2D�A�N�V����");
                sceneName = "2D�A�N�V����";
                break;
            case "�e�L�X�g(��߂�)":
                sleapevent.sleapeventStop();
                eventtriger.EventVewer = false;
                break;
        }

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
