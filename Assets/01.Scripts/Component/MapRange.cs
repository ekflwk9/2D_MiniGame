using UnityEngine;

public class MapRange : MonoBehaviour,
IAwake
{
    [Header("�� ����")]
    [SerializeField] private Vector2 range;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, range);
    }

    public void OnAwake()
    {
        GameManager.SetComponent(this);
    }
}
