using UnityEngine;
using UnityEngine.EventSystems;

public class FlappyBackButton : UiButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        GameManager.ChangeScene("Dungeon");
    }
}
