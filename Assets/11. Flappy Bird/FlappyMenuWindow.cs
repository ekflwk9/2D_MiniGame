using UnityEngine;

public class FlappyMenuWindow : MonoBehaviour
{
    private GameObject title;
    private GameObject gameOver;

    private void Awake()
    {
        title = Service.FindChild(this.transform, "TItle").gameObject;
        gameOver = Service.FindChild(this.transform, "GameOver").gameObject;

        GameManager.gameEvent.Add(FlappyOnMenu);
        GameManager.gameEvent.Add(FlappyOffMenu);
    }

    private void FlappyOnMenu()
    {
        this.gameObject.SetActive(true);
        gameOver.SetActive(true);
    }

    private void FlappyOffMenu()
    {
        this.gameObject.SetActive(false);
        if(title.activeSelf) title.SetActive(false);
    }
}
