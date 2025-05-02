using UnityEngine;

public class LoadComponent : MonoBehaviour
{
    private void Awake()
    {
        GameManager.effect.Load();
        GameManager.sound.Load();
    }
}
