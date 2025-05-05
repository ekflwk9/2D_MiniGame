using UnityEngine;

public class FlappyWall : MonoBehaviour
{
    private Transform target;

    private void Awake() => target = FindAnyObjectByType<FlappyCam>().transform;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            var nextPos = target.position;
            var minPos = nextPos.x + 11f;
            var maxPos = minPos + 20f;

            nextPos.x = Random.Range(minPos, maxPos);
            nextPos.y = this.transform.position.y;

            this.transform.position = nextPos;
        }
    }
}
