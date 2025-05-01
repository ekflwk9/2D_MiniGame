using UnityEngine;

public class EffectTime : MonoBehaviour
{
    [Header("�ش� ����Ʈ ��� �ð� ����")]
    [SerializeField] private float setOffTime = 1;

    public void SetTime()
    {
        var anim = GetComponent<Animator>();

        if (anim != null) anim.SetFloat("Speed", setOffTime);
        else Debug.Log($"{this.name}�� �ִϸ����Ͱ� �������� ����");

        DontDestroyOnLoad(this.gameObject);
    }

    private void SetOff() => this.gameObject.SetActive(false); //�ִϸ��̼� ȣ�� �޼���

    public void Destroy() => DestroyImmediate(this.gameObject);
}
