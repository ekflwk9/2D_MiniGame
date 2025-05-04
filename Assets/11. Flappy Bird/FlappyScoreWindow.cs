using TMPro;
using UnityEngine;

public class FlappyScoreWindow : MonoBehaviour
{
    private int score;
    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText =Service.FindChild(this.transform, "Text").GetComponent<TMP_Text>();

        GameManager.gameEvent.Add(FlappyResetScore);
        GameManager.gameEvent.Add(FlappyScore);
        GameManager.SetComponent(this);
    }

    private void FlappyResetScore()
    {
        score = 0;
        scoreText.text = $"Score : {score}";
    }

    private void FlappyScore()
    {
        score++;
        scoreText.text = $"Score : {score}";
    }
}
