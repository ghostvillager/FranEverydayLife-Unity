using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    void Start()
    {
        BGMManager.instance.PlayAudioClip(audioClip1);
    }

    public void soundplay(string soundName)
    {
        if(soundName == "2DƒAƒNƒVƒ‡ƒ“")
        {
            BGMManager.instance.PlayAudioClip(audioClip2);
        }
        else
        {
            BGMManager.instance.PlayAudioClip(audioClip1);
        }
    }
}