using UnityEngine;

public class EffectSound : MonoBehaviour,
IAwake
{
    private AudioSource source;

    public void OnAwake()
    {
        source = this.gameObject.AddComponent<AudioSource>();

        source.loop = false;
        source.playOnAwake = false;
        source.volume = 0.5f;

        GameManager.SetComponent(this);
    }

    public void On(AudioClip _sound) => source.PlayOneShot(_sound);
}
