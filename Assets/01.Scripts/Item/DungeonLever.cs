using UnityEngine;

public class DungeonLever : MonoBehaviour
{
    private GameObject onLever;
    private GameObject offLever;
    private GameObject info;

    private void Awake()
    {
        info = Service.FindChild(this.transform, "Info").gameObject;
        onLever = Service.FindChild(this.transform, "OnLever").gameObject;
        offLever = Service.FindChild(this.transform, "OffLever").gameObject;

        GameManager.gameEvent.Add(DungeonOnLever);
    }

    private void DungeonOnLever()
    {
        offLever.SetActive(false);
        onLever.SetActive(true);

        GameManager.sound.OnEffect("Lever");
        GameManager.fade.OnFade(FadeFunc);
    }

    private void FadeFunc()
    {
        GameManager.ChangeScene("Dungeon");
        GameManager.player.transform.position = Vector3.zero;
        GameManager.fade.OnFade();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) info.SetActive(true); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) info.SetActive(false);  
    }
}
