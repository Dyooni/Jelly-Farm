using UnityEngine;

public class ButtonOption : MonoBehaviour
{
    public bool isClick;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isClick) {
                panel.SetActive(true);
                Time.timeScale = 0;
                isClick = true;
                GameManager.instance.jelly.isLive = false;
            }
            else {
                panel.SetActive(false);
                Time.timeScale = 1;
                isClick = false;
                GameManager.instance.jelly.isLive = true;
            }
        }
    }
}
