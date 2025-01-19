using UnityEngine;
using UnityEngine.UI;

public class JellyPanel : MonoBehaviour
{
    public int page = 0;

    public Image unlockImg;
    public Image lockImg;
    public Text nameTxt;
    public Text goldTxt;
    public Text jelatineTxt;
    public Text pageTxt;

    public GameObject lockGroup;

    void Update()
    {
        unlockImg.sprite = GameManager.instance.jellySpriteList[page];
        lockImg.sprite = GameManager.instance.jellySpriteList[page];
        unlockImg.SetNativeSize();
        lockImg.SetNativeSize();
        nameTxt.text = GameManager.instance.jellyNameList[page];

        goldTxt.text = string.Format("{0:n0}", GameManager.instance.jellyGoldList[page]);
        jelatineTxt.text = string.Format("{0:n0}", GameManager.instance.jellyJelatineList[page]);
        pageTxt.text = string.Format("#{0:00}", page + 1);

        if (GameManager.instance.saveData.jellyUnlockList[page] == 0)
            lockGroup.SetActive(true);
        else if (GameManager.instance.saveData.jellyUnlockList[page] == 1)
            lockGroup.SetActive(false);
    }

    public void Unlock()
    {
        if (GameManager.instance.jelatineValue >= GameManager.instance.jellyJelatineList[page]) {
            GameManager.instance.saveData.jelatine -= GameManager.instance.jellyJelatineList[page];
            GameManager.instance.saveData.jellyUnlockList[page] = 1;
            GameManager.instance.soundManager.PlaySfx(9);
        }
        else {
            GameManager.instance.soundManager.PlaySfx(3);
        }
    }

    public void BuyCheck()
    {
        if (GameManager.instance.goldValue >= GameManager.instance.jellyGoldList[page] && GameManager.instance.jellyList.Count < GameManager.instance.saveData.numLevel * 2) {
            GameManager.instance.saveData.gold -= GameManager.instance.jellyGoldList[page];
            GameManager.instance.jellyGroup.BuySuccess();
        }
        else {
            GameManager.instance.soundManager.PlaySfx(3);
        }
    }
}
