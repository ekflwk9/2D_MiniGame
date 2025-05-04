using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [Header("Ǯ�� ī��Ʈ")]
    [SerializeField] private int spawnCount;

    private float stage;
    private Vector2 spawnPoint;

    private Animator anim;
    private Dictionary<int, Monster[]> monsters = new Dictionary<int, Monster[]>();

    private void Start()
    {
        GameManager.SetComponent(this);
        GameManager.gameEvent.Add(UpDifficulty, false);

        anim = GetComponent<Animator>();
        if (anim == null) Debug.Log($"{this.name}�� �ִϸ����Ͱ� �������� ����");

        var monsterResource = Resources.LoadAll<GameObject>("Monster");

        for (int i = 0; i < monsterResource.Length; i++)
        {
            //���� ����
            var tempArray = new Monster[spawnCount];

            for (int I = 0; I < tempArray.Length; I++)
            {
                var monster = Instantiate(monsterResource[i]);
                var component = monster.GetComponent<Monster>();
                monster.name = $"{monsterResource[i].name}{I}";

                if (component != null) component.SetMonster();
                else Debug.Log($"{monsterResource[i]}�� Monster ������Ʈ�� �������� ����");

                tempArray[I] = component;
            }

            //���� �Ҵ�
            monsters.Add(i, tempArray);
        }
    }

    private void UpDifficulty()
    {
        stage += 0.2f;
        anim.SetFloat("Speed", stage);
    }

    private void Spawn()
    {
        var ranSpawn = Random.Range(0, monsters.Count);
        var camRange = GameManager.cam.range;

        spawnPoint.x = Random.Range(camRange.x * -0.4f, camRange.x * 0.4f);
        spawnPoint.y = Random.Range(camRange.y * -0.4f, camRange.y * 0.4f);

        for (int i = 0; i < monsters[ranSpawn].Length; i++)
        {
            if (!monsters[ranSpawn][i].gameObject.activeSelf)
            {
                monsters[ranSpawn][i].transform.position = spawnPoint;
                monsters[ranSpawn][i].gameObject.SetActive(true);
                break;
            }
        }
    }
}
