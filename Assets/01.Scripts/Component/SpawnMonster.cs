using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour,
IAwake
{
    private Dictionary<string, Monster[]> monsters = new Dictionary<string, Monster[]>();

    public void OnAwake()
    {
        var monsterResource = Resources.LoadAll<GameObject>("Monster");

        for (int i = 0; i < monsterResource.Length; i++)
        {

        }
    }
}
