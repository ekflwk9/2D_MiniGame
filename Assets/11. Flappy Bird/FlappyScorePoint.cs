using UnityEngine;

public class FlappyScorePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.gameEvent.Call("FlappyScore");
        }
    }
}
