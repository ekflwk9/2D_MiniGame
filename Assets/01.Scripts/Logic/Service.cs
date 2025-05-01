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

    public static GameObject FindResource(string _name)
    {
        var findObject = Resources.Load<GameObject>(_name).gameObject;
        if (findObject == null) Debug.Log($"{_name}은 존재하지 않는 무기종류");
        
        return findObject;
    }

    public static GameObject FindResource(string _fileName, string _name)
    {
        var findObject = Resources.Load<GameObject>($"{_fileName}/{_name}").gameObject;
        if (findObject == null) Debug.Log($"{_name}은 존재하지 않는 임펙트");

        return findObject;
    }
}
