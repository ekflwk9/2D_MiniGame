using UnityEngine;

public static class GameManager
{
    public static PlayerComponent player { get; private set; }
    public static CameraComponent cam { get; private set; }

    public static void SetComponent(MonoBehaviour _component)
    {
        if (_component is PlayerComponent isPlayer) player = isPlayer;
        else if (_component is CameraComponent isCam) cam = isCam;
    }
}
