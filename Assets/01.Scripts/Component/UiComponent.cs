using UnityEngine;

public class UiComponent : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameManager.SetComponent(this);
    }
}
