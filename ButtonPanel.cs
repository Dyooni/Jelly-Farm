using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour
{
    public bool isClick = false;
    public bool isLive = true;

    public Sprite showSprite;
    public Sprite hideSprite;
    public GameObject panel;
    public Animator panelAnim;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();    
    }

    void Update()
    {
        if (isClick && Input.GetKeyDown(KeyCode.Escape)) {
            panelAnim.SetTrigger("doHide");
            image.sprite = hideSprite;
            isClick = false;
            GameManager.instance.jelly.isLive = true;
        }
    }

    public void ButtonClick()
    {
        if (!isClick) {
            panelAnim.SetTrigger("doShow");
            image.sprite = showSprite;
            isClick = true;
            GameManager.instance.jelly.isLive = false;
        }
        else {
            panelAnim.SetTrigger("doHide");
            image.sprite = hideSprite;
            isClick = false;
            GameManager.instance.jelly.isLive = true;
        }
    }
}
