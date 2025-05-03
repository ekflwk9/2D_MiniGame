using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("¸Ê ¹üÀ§")]
    [SerializeField] private Vector2 fieldRange;
    public Vector2 range { get => fieldRange; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, fieldRange);
    }

    private void Start()
    {
        GameManager.cam.SetRange(range);
        GameManager.sound.OnMusic(this.name);
        GameManager.SetComponent(this);
    }
}
