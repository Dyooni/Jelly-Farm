using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isSell = false;

    Collider2D btnCollider;

    GameManager gameManager;

    void Awake()
    {
        btnCollider = GetComponent<Collider2D>();
    }

    public void GetGold()
    {
        
        GameManager.instance.saveData.gold += GameManager.instance.jellyGoldList[GameManager.instance.jelly.id] 
                                                * GameManager.instance.jelly.level;
        Mathf.Min(GameManager.instance.saveData.gold, 99999999);
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        isSell = true;
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        isSell = false;
    }

    public void ClickSell()
    {
        GameManager.instance.soundManager.sfxPlayer.PlayOneShot(GameManager.instance.soundManager.sfxClip[0]);
        GameManager.instance.noticManager.Message("Sell");
    }
}
