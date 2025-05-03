using UnityEngine;

public class FlappyCam : MonoBehaviour
{
    private Transform target;
    private Vector3 nextPos;

    private void Awake()
    {
        target = FindAnyObjectByType<FlappyControll>().transform;
        if (target == null) Debug.Log($"FlappyPlayer를 찾을 수 없음");
    }

    private void Update()
    {
        nextPos.x = target.position.x;
        this.transform.position = nextPos;
    }
}
