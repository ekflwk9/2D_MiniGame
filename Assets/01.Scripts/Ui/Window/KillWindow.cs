using TMPro;
using UnityEngine;

public class KillWindow : MonoBehaviour,
IGameEvent
{
    private int killCount;
    private TMP_Text killText;

    private void Awake()
    {
        killText = Service.FindChild(this.transform, "Text").GetComponent<TMP_Text>();
        GameManager.SetComponent(this);
    }

    public void OnGameEvent()
    {
        killCount++;
        killText.text = $"Kill : {killCount}";
    }
}
