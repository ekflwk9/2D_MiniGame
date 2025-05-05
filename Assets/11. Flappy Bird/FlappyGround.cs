using UnityEngine;

public class FlappyGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            var nextPos = this.transform.position;
            nextPos.x = nextPos.x + 36f;

            this.transform.position = nextPos;
        }
    }
}
