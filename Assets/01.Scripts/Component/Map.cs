using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("배경음")]
    [SerializeField] private string musicName;

    [Space(10f)]
    [Header("맵 범위")]
    [SerializeField] private Vector2 fieldRange;
    public Vector2 range { get => fieldRange; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, fieldRange);
    }

    private void Start()
    {
        if(!string.IsNullOrEmpty(musicName)) GameManager.sound.OnMusic(musicName);

        GameManager.cam.SetRange(range);
        GameManager.SetComponent(this);
    }
}
