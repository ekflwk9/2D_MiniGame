using System;
using UnityEngine;

public enum EffectCode
{
    Arrow = 0,
    Walk = 1,
    Blood = 2,
}

public class EffectManager
{
    //�迭�� ��ųʸ�ó�� ���� !
    private GameObject[][] effects;

    public void Load()
    {
        var resource = Resources.LoadAll<GameObject>("Effect");
        effects = new GameObject[resource.Length][];

        for (int i = 0; i < resource.Length; i++)
        {
            //Enum�� ��������
            var effectCode = EffectCode.Arrow;
            if (!Enum.TryParse(resource[i].name, out effectCode)) Debug.Log($"{resource[i].name}�� EffectCode�� ���� �̸�");

            //�ش� ������Ʈ Enum�� �°� �Ҵ�, �ʱ�ȭ
            var length = resource.Length * 5;
            var index = (int)effectCode;
            effects[index] = new GameObject[length];

            //������Ʈ �ϳ��� 10���� Ǯ���� ������
            for (int I = 0; I < length; I++)
            {
                var gameObject = MonoBehaviour.Instantiate(resource[i]);
                var component = gameObject.GetComponent<EffectTime>();

                if (component != null) component.SetTime();
                else Debug.Log($"{resource[i]}�� EffectTime������Ʈ�� �������� ����");

                effects[index][I] = gameObject;
                gameObject.SetActive(false);
            }
        }
    }

    public void On(Vector3 _spawnPos, EffectCode _code)
    {
        var index = (int)_code;
        var length = effects[index].Length;

        //�ش� ������Ʈ �迭 �ȿ� �����ִ� �迭�� Ȱ��ȭ
        for (int i = 0; i < length; i++)
        {
            if (!effects[index][i].activeSelf)
            {
                effects[index][i].transform.position = _spawnPos;
                effects[index][i].SetActive(true);
                break;
            }
        }
    }

    public void OnEffect(Vector3 _spawnPos, Vector3 _direction, EffectCode _code)
    {
        var index = (int)_code;
        var length = effects[index].Length;

        //�ش� ������Ʈ �迭 �ȿ� �����ִ� �迭�� Ȱ��ȭ
        for (int i = 0; i < length; i++)
        {
            if (!effects[index][i].activeSelf)
            {
                effects[index][i].transform.position = _spawnPos;
                effects[index][i].transform.localScale = _direction;
                effects[index][i].SetActive(true);
                break;
            }
        }
    }
}