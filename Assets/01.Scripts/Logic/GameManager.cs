using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static bool stopGame = false;
    public static PlayerComponent player { get; private set; }
    public static CameraComponent cam { get; private set; }
    public static FadeComponent fade { get; private set; }
    public static Weapon weapon { get; private set; }
    public static SoundManager sound { get; private set; } = new SoundManager();
    public static EffectManager effect { get; private set; } = new EffectManager();
    public static EventManager gameEvent { get; private set; } = new EventManager();

    public static void SetComponent(MonoBehaviour _component)
    {
        if (_component is Weapon isWeapon) weapon = isWeapon;
        else if (_component is PlayerComponent isPlayer) player = isPlayer;
        else if (_component is CameraComponent isCam) cam = isCam;
        else if (_component is FadeComponent isFade) fade = isFade;

        sound.SetComponent(_component);
        gameEvent.SetComponent(_component);
    }

    public static void ChangeScene(string _sceneName)
    {
        if (_sceneName == "Loby")
        {
            gameEvent.Reset(true);
        }

        else
        {
            gameEvent.Reset(false);
            gameEvent.SetComponent(player);

            player.transform.position = Vector3.zero;
        }

        SceneManager.LoadScene(_sceneName);
    }
}
