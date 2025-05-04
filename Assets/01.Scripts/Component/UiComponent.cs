using UnityEngine;

public class UiComponent : MonoBehaviour,
IDestroy
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameManager.SetComponent(this);
    }

    public void OnDestroyHandler() => Destroy(this.gameObject);
}
