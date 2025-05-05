using UnityEngine.EventSystems;

public class FlappyStartButton : UiButton
{
    protected override void Click()
    {
        GameManager.gameEvent.Call("FlappyResetScore");
        GameManager.gameEvent.Call("FlappyOffMenu");
        GameManager.gameEvent.Call("FlappyStart");

        touchImage.SetActive(false);
    }
}
