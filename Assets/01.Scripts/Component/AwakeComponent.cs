using UnityEngine;

public class AwakeComponent : MonoBehaviour
{
    //비활성화 되어있는 오브젝트 상관없이 모두 호출
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
