using UnityEngine;
using UnityEngine.UI;

public class JellyButtonState : MonoBehaviour
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
            if (GameManager.instance.plantBtnState.isClick) {
                GameManager.instance.plantBtnState.panelAnim.SetTrigger("doHide");
                GameManager.instance.plantBtnState.image.sprite = GameManager.instance.plantBtnState.hideSprite;
                GameManager.instance.plantBtnState.isClick = false;
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
    }
}
