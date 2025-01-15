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
                GameManager.instance.jelly.isLive = true;
            }
            else if (GameManager.instance.plantBtnState.isClick) {
                GameManager.instance.plantBtnState.panelAnim.SetTrigger("doHide");
                GameManager.instance.plantBtnState.image.sprite = GameManager.instance.plantBtnState.hideSprite;
                GameManager.instance.plantBtnState.isClick = false;
                GameManager.instance.jelly.isLive = true;
            }
            else if (!isClick) {
                panel.SetActive(true);
                Time.timeScale = 0;
                isClick = true;
            }
            else if (isClick) {
                panel.SetActive(false);
                Time.timeScale = 1;
                isClick = false;
            }
        }
    }
}
