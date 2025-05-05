using UnityEngine;
using UnityEngine.EventSystems;

public class FlappyBackButton : UiButton
{
    protected override void Click()
    {
        GameManager.fade.OnFade(FadeFunc);
    }

    private void FadeFunc()
    {
        GameManager.ChangeScene("Loby");
        GameManager.fade.OnFade();

        GameManager.stopGame = false;
        GameManager.player.transform.position = new Vector3(-5, 7, 0);
    }
}
