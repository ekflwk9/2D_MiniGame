using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private Dictionary<string, IHit> hit = new Dictionary<string, IHit>();

    public void SetComponent(MonoBehaviour _component)
    {
        if(_component is IHit isHit)
        {
            if (!hit.ContainsKey(_component.name)) hit.Add(_component.name, isHit);
        }
    }

    public void Hit(string _eventName, int _dmg = 0)
    {
        if (hit.ContainsKey(_eventName)) hit[_eventName].OnHit(_dmg);
        else Debug.Log($"{_eventName}는 없는 이벤트");
    }
}
