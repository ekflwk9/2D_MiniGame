using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public Vector2 range { get; private set; }
    private Vector2 size;
    private Vector2 nextPos;

    private Animator anim;
    private Transform target;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindFirstObjectByType<PlayerComponent>().transform;
        if (target == null) Debug.Log("플레이어가 존재하지 않음");

        size = new Vector2(17.78f, 10f);
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        //내 위치 => 플레이어 위치 추적
        if (target != null)
        {
            var thisPos = this.transform.position;
            nextPos = Vector2.Lerp(thisPos, target.transform.position, 0.015f);

            //카메라 위치 + 카메라 사이즈
            var camSize = size * 0.5f;
            var right = nextPos + camSize;
            var left = nextPos + (camSize * -1);

            //맵 사이즈
            var rightRange = range * 0.5f;
            var leftRange = range * -0.5f;

            //x축 검사
            if (right.x > rightRange.x) nextPos.x = rightRange.x - camSize.x;
            else if (left.x < leftRange.x) nextPos.x = leftRange.x + camSize.x;

            //y축 검사
            if (right.y > rightRange.y) nextPos.y = rightRange.y - camSize.y;
            else if (left.y < leftRange.y) nextPos.y = leftRange.y + camSize.y;

            //위치 설정
            this.transform.position = nextPos;
        }
    }

    public void SetRange(Vector2 _range) => range = _range;
    public void Shake() => anim.Play("Shake", 0, 0);
    public void HitShake() => anim.Play("Hit", 0, 0);
}
