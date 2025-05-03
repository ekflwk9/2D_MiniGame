using System.Text;
using UnityEngine;

public class FadeComponent : MonoBehaviour
{
    private Animator anim;
    private StringBuilder eventName = new StringBuilder(30);

    private void Awake() => anim = GetComponent<Animator>();

    public void OnFade(string _eventName, bool _fadeOut = false, float _fadeSpeed = 1f)
    {
        eventName.Append(_eventName);
        anim.SetFloat("Speed", _fadeSpeed);
        anim.Play(_fadeOut ? "FadeOut" : "FadeIn", 0, 0);
    }

    private void EndFade()
    {
        //애니메이션 호출 메서드
        if(string.IsNullOrEmpty(eventName.ToString()))
        {
            GameManager.gameEvent.GameEvent(eventName.ToString());
            eventName.Clear();
        } 
    }
}
