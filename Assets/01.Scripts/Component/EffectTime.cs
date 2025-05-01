using UnityEngine;

public class EffectTime : MonoBehaviour
{
    [Header("해당 임펙트 재생 시간 설정")]
    [SerializeField] private float setOffTime = 1;

    public void SetTime()
    {
        var anim = GetComponent<Animator>();

        if (anim != null) anim.SetFloat("Speed", setOffTime);
        else Debug.Log($"{this.name}은 애니메이터가 존재하지 않음");

        DontDestroyOnLoad(this.gameObject);
    }

    private void SetOff() => this.gameObject.SetActive(false); //애니메이션 호출 메서드

    public void Destroy() => DestroyImmediate(this.gameObject);
}
