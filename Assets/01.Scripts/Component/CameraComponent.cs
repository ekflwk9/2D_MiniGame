using UnityEngine;

public class CameraComponent : MonoBehaviour,
IStart
{
    private Animator anim;
    private Transform target;

    public void OnStart()
    {
        anim = GetComponent<Animator>();
        target = GameManager.player.transform;
        if (target == null) Debug.Log("�÷��̾ �������� ����");

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        //�� ��ġ => �÷��̾� ��ġ ����
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 0.015f);
    }
}
