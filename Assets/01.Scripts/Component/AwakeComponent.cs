using UnityEngine;

public class AwakeComponent : MonoBehaviour
{
    //��Ȱ��ȭ �Ǿ��ִ� ������Ʈ ������� ��� ȣ��
    private void Awake() => FindComponent(this.transform);

    private void FindComponent(Transform _parent)
    {
        var awakeComponent = _parent.GetComponent<IAwake>();
        if (awakeComponent != null) awakeComponent.OnAwake();
        FindChild(_parent);
    }

    private void FindChild(Transform _parent)
    {
        for (int i = 0; i < _parent.childCount; i++)
        {
            var child = _parent.GetChild(i);
            FindComponent(child);
        }
    }
}
