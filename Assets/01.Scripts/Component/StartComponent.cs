using UnityEngine;

public class StartComponent : MonoBehaviour
{
    //��Ȱ��ȭ �Ǿ��ִ� ������Ʈ ������� ��� ȣ��
    private void Start() => FindComponent(this.transform);

    private void FindComponent(Transform _parent)
    {
        var awakeComponent = _parent.GetComponent<IStart>();
        if (awakeComponent != null) awakeComponent.OnStart();
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
