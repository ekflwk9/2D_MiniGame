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
        if (target == null) Debug.Log("플레이어가 존재하지 않음");

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        //내 위치 => 플레이어 위치 추적
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 0.015f);
    }
}
