using UnityEngine;

public class PageButton : MonoBehaviour
{
    public JellyPanel jellyPanel;

    public void PageUp()
    {
        if (jellyPanel.page < 11) {
            jellyPanel.page++;

            GameManager.instance.soundManager.PlaySfx(0);
        }
    }

    public void PageDown()
    {
        if (jellyPanel.page > 0) {
            jellyPanel.page--;

            GameManager.instance.soundManager.PlaySfx(0);
        }
    }
}
