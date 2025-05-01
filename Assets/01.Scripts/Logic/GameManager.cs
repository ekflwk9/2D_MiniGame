using UnityEngine;

public static class GameManager
{
    public static PlayerController player { get; private set; }
    public static CameraComponent cam { get; private set; }
    public static Weapon weapon { get; private set; }

    public static void SetComponent(MonoBehaviour _component)
    {
        if (_component is Weapon isWeapon) weapon = isWeapon;
        else if (_component is PlayerController isPlayer) player = isPlayer;
        else if (_component is CameraComponent isCam) cam = isCam;
    }
}
