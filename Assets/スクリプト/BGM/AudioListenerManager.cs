using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    void Awake()
    {
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        if (audioListeners.Length > 1)
        {
            for (int i = 1; i < audioListeners.Length; i++)
            {
                Destroy(audioListeners[i]);
            }
        }
    }
}
