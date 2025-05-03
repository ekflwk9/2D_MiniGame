using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private Dictionary<string, IHit> hit = new Dictionary<string, IHit>();
    private Dictionary<string, IGameEvent> gameEvent = new Dictionary<string, IGameEvent>();
    private Dictionary<string, IConstEvent> constEvent = new Dictionary<string, IConstEvent>();
    private event Func destroy;

    public void SetComponent(MonoBehaviour _component)
    {
        if (_component is IHit isHit)
        {
            if (!hit.ContainsKey(_component.name)) hit.Add(_component.name, isHit);
        }

        if (_component is IGameEvent isEvent)
        {
            if (!gameEvent.ContainsKey(_component.name)) gameEvent.Add(_component.name, isEvent);
        }

        if (_component is IConstEvent isConst)
        {
            if (!constEvent.ContainsKey(_component.name)) constEvent.Add(_component.name, isConst);
        }

        if (_component is IDestroy isDestroy)
        {
            destroy += isDestroy.OnDestroyHandler;
        }
    }

    public void Reset(bool _isReset)
    {
        hit.Clear();
        gameEvent.Clear();

        if (_isReset)
        {
            constEvent.Clear();
            destroy?.Invoke();
        }
    }

    public void Hit(string _eventName, int _dmg = 0)
    {
        if (hit.ContainsKey(_eventName)) hit[_eventName].OnHit(_dmg);
        else Debug.Log($"{_eventName}는 없는 히트 이벤트");
    }

    public void GameEvent(string _eventName)
    {
        if (gameEvent.ContainsKey(_eventName)) gameEvent[_eventName].OnGameEvent();
        else Debug.Log($"{_eventName}는 없는 게임 이벤트");
    }

    public void ConstEvent(string _eventName)
    {
        if (constEvent.ContainsKey(_eventName)) constEvent[_eventName].OnConstEvent();
        else Debug.Log($"{_eventName}는 없는 고정 이벤트");
    }
}
