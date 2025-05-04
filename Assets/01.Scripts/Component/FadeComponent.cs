using UnityEngine;

public class FadeComponent : MonoBehaviour
{
    private Animator anim;
    private Func fadeFunc;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.SetComponent(this);
    }

    public void OnFade(Func _fadeFunc, float _fadeSpeed = 1f)
    {
        fadeFunc = _fadeFunc;
        anim.SetFloat("Speed", _fadeSpeed);
        anim.Play("FadeIn", 0, 0);
    }

    public void OnFade(float _fadeSpeed = 1f)
    {
        anim.SetFloat("Speed", _fadeSpeed);
        anim.Play("FadeOut", 0, 0);
    }

    private void EndFade()
    {
        //�ִϸ��̼� ȣ�� �޼���
        if (fadeFunc != null)
        {
            fadeFunc();
            fadeFunc = null;
        }
    }
}
