using UnityEngine;

public class Map : MonoBehaviour,
IStart
{
    [Header("¸Ê ¹üÀ§")]
    [SerializeField] public Vector2 range { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, range);
    }

    public void OnStart()
    {
        GameManager.sound.OnMusic(this.name);
        GameManager.SetComponent(this);
    }
}
