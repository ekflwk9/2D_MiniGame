using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    private Dictionary<string, AudioClip> sound = new Dictionary<string, AudioClip>();

    private EffectSound effect;
    private MusicSound music;

    public void Load()
    {
        var sounds = Resources.LoadAll<GameObject>("Sound");

        for (int i = 0; i < sounds.Length; i++)
        {
            var component = sounds[i].GetComponent<AudioSource>();
            if (component == null) Debug.Log($"{sounds[i]}�� AudioSource ������Ʈ�� �������� ����");

            sound.Add(sounds[i].name, component.clip);
        }
    }

    public void SetComponent(MonoBehaviour _component)
    {
        if (_component is EffectSound isEffect) effect = isEffect;
        else if (_component is MusicSound isMusic) music = isMusic;
    }

    public void OnEffect(string _soundName) 
    {
        if (sound.ContainsKey(_soundName)) effect.On(sound[_soundName]);
        else Debug.Log($"{_soundName}�� Ǯ�� ���忡 ���� ����");
    }

    public void OnMusic(string _soundName)
    {
        if (sound.ContainsKey(_soundName)) music.On(sound[_soundName]);
        else Debug.Log($"{_soundName}�� Ǯ�� ���忡 ���� ����");
    }
}
