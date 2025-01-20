using UnityEngine;

public class ButtonOption : MonoBehaviour
{
    public bool isClick = false;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameManager.instance.jellyBtnState.isClick) {
                GameManager.instance.jellyBtnState.panelAnim.SetTrigger("doHide");
                GameManager.instance.jellyBtnState.image.sprite = GameManager.instance.jellyBtnState.hideSprite;
                GameManager.instance.jellyBtnState.isClick = false;
                GameManager.instance.jellyGroup.isLive = true;
                GameManager.instance.soundManager.PlaySfx(0);
            }
            else if (GameManager.instance.plantBtnState.isClick) {
                GameManager.instance.plantBtnState.panelAnim.SetTrigger("doHide");
                GameManager.instance.plantBtnState.image.sprite = GameManager.instance.plantBtnState.hideSprite;
                GameManager.instance.plantBtnState.isClick = false;
                GameManager.instance.jellyGroup.isLive = true;
                GameManager.instance.soundManager.PlaySfx(0);
            }
            else if (!isClick) {
                panel.SetActive(true);
                Time.timeScale = 0;
                isClick = true;

                GameManager.instance.soundManager.PlaySfx(5);
            }
            else if (isClick) {
                panel.SetActive(false);
                Time.timeScale = 1;
                isClick = false;

                GameManager.instance.soundManager.PlaySfx(6);
            }
        }
    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        isClick = false;

        GameManager.instance.soundManager.PlaySfx(6);
    }

    public void GameExit()
    {
        GameManager.instance.soundManager.PlaySfx(6);

        Invoke("AppQuit", 0.5f);
    }

    void AppQuit()
    {
        Application.Quit();
    }
}
