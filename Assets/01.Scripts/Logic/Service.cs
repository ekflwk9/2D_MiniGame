using UnityEngine;

public delegate void Func();
public interface IAwake { public void OnAwake(); }
public interface IStart { public void OnStart(); }

public class Service
{
    public static Transform FindChild(Transform _parent, string _childName)
    {
        Transform findChild = null;

        for (int i = 0; i < _parent.childCount; i++)
        {
            var child = _parent.GetChild(i);
            findChild = child.name == _childName ? child : FindChild(child, _childName);
            if (findChild != null) break;
        }

        return findChild;
    }
}
