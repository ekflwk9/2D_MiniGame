using UnityEngine;
using UnityEngine.EventSystems;

public class FlappyStartButton : UiButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        GameManager.gameEvent.Call("FlappyResetScore");
        GameManager.gameEvent.Call("FlappyOffMenu");
        GameManager.gameEvent.Call("FlappyStart");
    }
}
