using UnityEngine;

public class Map : MonoBehaviour,
IStart
{
    [Header("¸Ê ¹üÀ§")]
    [SerializeField] private Vector2 fieldRange;
    public Vector2 range { get => fieldRange; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, fieldRange);
    }

    public void OnStart()
    {
        GameManager.sound.OnMusic(this.name);
        GameManager.SetComponent(this);
    }
}
