using System.Collections.Generic;
using UnityEngine;

public class EffectManager
{
    private Dictionary<string, GameObject> effect = new Dictionary<string, GameObject>();

    public void Load()
    {
        var effects = Resources.LoadAll<GameObject>("Effect");

        for (int i = 0; i < effects.Length; i++)
        {
            var gameObject = MonoBehaviour.Instantiate(effects[i]);
            var component = gameObject.GetComponent<EffectTime>();

            if (component != null) component.SetTime();
            else Debug.Log($"{effects[i]}�� EffectTime������Ʈ�� �������� ����");

            effect.Add(effects[i].name, gameObject);
        }
    }

    public void On(Vector3 _spawnPos, string _effectName)
    {
        if (effect.ContainsKey(_effectName))
        {
            effect[_effectName].transform.position = _spawnPos;
            effect[_effectName].SetActive(true);
        }

        else Debug.Log($"{_effectName}�� ���� ����Ʈ");
    }
}
