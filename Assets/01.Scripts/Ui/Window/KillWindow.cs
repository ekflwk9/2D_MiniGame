using TMPro;
using UnityEngine;

public class KillWindow : MonoBehaviour
{
    private int killCount;
    private TMP_Text killText;

    private void Awake()
    {
        killText = Service.FindChild(this.transform, "Text").GetComponent<TMP_Text>();

        GameManager.gameEvent.Add(UpKillCount);
        GameManager.SetComponent(this);
    }

    private void UpKillCount()
    {
        killCount++;
        killText.text = $"Kill : {killCount}";
    }
}
