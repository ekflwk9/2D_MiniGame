using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiButton : MonoBehaviour,
IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected GameObject touchImage;
    protected TMP_Text button;

    protected virtual void Awake()
    {
        touchImage = Service.FindChild(this.transform, "Touch").gameObject;
        if (touchImage == null) Debug.Log($"{this.name}�� Tocuh������Ʈ�� ����");

        button = Service.FindChild(this.transform, "Text").GetComponent<TMP_Text>();
        if (button == null) Debug.Log($"{this.name}�� Text������Ʈ�� ����");
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public void OnPointerEnter(PointerEventData eventData) => touchImage.SetActive(true);

    public void OnPointerExit(PointerEventData eventData) => touchImage.SetActive(false);
}
