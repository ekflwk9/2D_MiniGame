using UnityEngine;

public class FlappyLever : MonoBehaviour
{
    private GameObject onLever;
    private GameObject offLever;
    private GameObject info;

    private void Awake()
    {
        info = Service.FindChild(this.transform, "Info").gameObject;
        onLever = Service.FindChild(this.transform, "OnLever").gameObject;
        offLever = Service.FindChild(this.transform, "OffLever").gameObject;

        GameManager.gameEvent.Add(FlappyOnLever);
    }

    private void FlappyOnLever()
    {
        offLever.SetActive(false);
        onLever.SetActive(true);
        GameManager.gameEvent.Call("StopPlayer", true);

        GameManager.stopGame = true;
        GameManager.sound.OnEffect("Lever");
        GameManager.fade.OnFade(FadeFunc);
    }

    private void FadeFunc()
    {
        GameManager.ChangeScene("Flappy");
        GameManager.sound.OnMusic(null);

        GameManager.player.transform.position = Vector3.down * 1000;
        GameManager.fade.OnFade();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) info.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) info.SetActive(false);
    }
}
