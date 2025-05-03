using TMPro;
using UnityEngine;

public class FlappyScore : MonoBehaviour,
IGameEvent
{
    private int score;
    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        GameManager.SetComponent(this);
    }

    public void OnGameEvent()
    {
        score++;
        scoreText.text = $"Score{score}";
    }
}
