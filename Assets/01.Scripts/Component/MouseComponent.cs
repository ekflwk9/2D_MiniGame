using Unity.Mathematics;
using UnityEngine;

public class MouseComponent : MonoBehaviour,
IStart
{
    private Vector3 direction = Vector3.one;
    private Vector3 mousePos;
    private Transform target;

    public void OnStart() => target = GameManager.player.transform;

    private void Update()
    {
        //���콺 ������
        mousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition) - target.position;

        //���콺 ��ġ�� ���� �� ����
        if (mousePos.x < 0) direction.y = -1;
        else direction.y = 1;

        //�����̼� ����
        var atan = math.atan2(mousePos.y, mousePos.x);
        var deg = math.degrees(atan);

        //���Ϸ��� ����
        this.transform.rotation = Quaternion.Euler(0, 0, deg);
        this.transform.localScale = direction;
    }
}
