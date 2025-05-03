using UnityEngine;

public class MusicSound : MonoBehaviour,
IAwake
{
    private AudioSource source;

    public void OnAwake()
    {
        source = this.gameObject.AddComponent<AudioSource>();

        source.loop = true;
        source.playOnAwake = false;
        source.volume = 0.5f;

        GameManager.SetComponent(this);
    }

    public void On(AudioClip _sound)
    {
        if (_sound != null)
        {
            source.clip = _sound;
            source.Play();
        }

        else
        {
            source.Stop();
        }
    }
}
