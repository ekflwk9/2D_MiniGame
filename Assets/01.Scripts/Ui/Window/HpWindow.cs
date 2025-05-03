using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpWindow : MonoBehaviour,
IStart, IConstEvent
{
    private Slider slider;
    private TMP_Text hpText;

    public void OnStart()
    {
        slider = GetComponent<Slider>();
        hpText = Service.FindChild(this.transform, "HpText").GetComponent<TMP_Text>();

        slider.maxValue = GameManager.player.health;
        slider.value = GameManager.player.health;

        hpText.text = $"{slider.value} / {slider.maxValue}";
        GameManager.SetComponent(this);
    }

    public void OnConstEvent()
    {
        slider.value = GameManager.player.health;
        hpText.text = $"{slider.value} / {slider.maxValue}";
    }
}
