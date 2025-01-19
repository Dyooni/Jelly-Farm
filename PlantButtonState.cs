using UnityEngine;
using UnityEngine.UI;

public class PlantButtonState : MonoBehaviour
{
    public bool isClick = false;
    
    public Sprite showSprite;
    public Sprite hideSprite;
    public Animator panelAnim;

    public Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ButtonClick()
    {
        if (!isClick) {
            if (GameManager.instance.jellyBtnState.isClick) {
                GameManager.instance.jellyBtnState.panelAnim.SetTrigger("doHide");
                GameManager.instance.jellyBtnState.image.sprite = GameManager.instance.jellyBtnState.hideSprite;
                GameManager.instance.jellyBtnState.isClick = false;
            }
            panelAnim.SetTrigger("doShow");
            image.sprite = showSprite;
            isClick = true;
            GameManager.instance.jellyGroup.isLive = false;
        }
        else {
            panelAnim.SetTrigger("doHide");
            image.sprite = hideSprite;
            isClick = false;
            GameManager.instance.jellyGroup.isLive = true;
        }

        GameManager.instance.soundManager.PlaySfx(0);
    }
}
