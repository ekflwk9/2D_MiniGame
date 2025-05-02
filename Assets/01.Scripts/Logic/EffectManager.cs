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
    //배열로 딕셔너리처럼 도전 !
    private GameObject[][] effects;

    public void Load()
    {
        var resource = Resources.LoadAll<GameObject>("Effect");
        effects = new GameObject[resource.Length][];

        for (int i = 0; i < resource.Length; i++)
        {
            //Enum값 가져오기
            var effectCode = EffectCode.Arrow;
            if (!Enum.TryParse(resource[i].name, out effectCode)) Debug.Log($"{resource[i].name}은 EffectCode에 없는 이름");

            //해당 오브젝트 Enum에 맞게 할당, 초기화
            var length = resource.Length * 5;
            var index = (int)effectCode;
            effects[index] = new GameObject[length];

            //오브젝트 하나당 10개의 풀링을 갖게함
            for (int I = 0; I < length; I++)
            {
                var gameObject = MonoBehaviour.Instantiate(resource[i]);
                var component = gameObject.GetComponent<EffectTime>();

                if (component != null) component.SetTime();
                else Debug.Log($"{resource[i]}는 EffectTime컴포넌트가 존재하지 않음");

                effects[index][I] = gameObject;
                gameObject.SetActive(false);
            }
        }
    }

    public void On(Vector3 _spawnPos, EffectCode _code)
    {
        var index = (int)_code;
        var length = effects[index].Length;

        //해당 오브젝트 배열 안에 꺼져있는 배열만 활성화
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

        //해당 오브젝트 배열 안에 꺼져있는 배열만 활성화
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