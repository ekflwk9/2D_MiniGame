using Unity.Mathematics;
using UnityEngine;

public class MouseController : MonoBehaviour,
IStart
{
    private Vector3 direction = Vector3.one;
    private Vector3 mousePos;
    private Transform target;

    public void OnStart() => target = GameManager.player.transform;

    private void Update()
    {
        MoveMouse();
        ClickDown();
        ClickUp();
    }

    private void MoveMouse()
    {
        //���콺 ������
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - target.position;

        //���콺 ��ġ�� ���� ����
        if (mousePos.x < 0)
        {
            GameManager.player.Direction(true);
            direction.x = -1;
        }
        else
        {
            GameManager.player.Direction(false);
            direction.x = 1;
        }

        //�����̼� ����
        var atan = math.atan2(mousePos.y, mousePos.x);
        var deg = math.degrees(atan);

        //���Ϸ��� ����
        this.transform.rotation = Quaternion.Euler(0, 0, deg);
        this.transform.localScale = direction;
    }

    private void ClickDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameManager.weapon != null) GameManager.weapon.Ready();
        }
    }

    private void ClickUp()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (GameManager.weapon != null) GameManager.weapon.Attack();
        }
    }
}
