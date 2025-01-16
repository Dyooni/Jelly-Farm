using System;
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

    void Update()
    {
        unlockImg.sprite = GameManager.instance.jellySpriteList[page];
        lockImg.sprite = GameManager.instance.jellySpriteList[page];
        nameTxt.text = GameManager.instance.jellyNameList[page];

        goldTxt.text = string.Format("{0:n0}", GameManager.instance.jellyGoldList[page]);
        jelatineTxt.text = string.Format("{0:n0}", GameManager.instance.jellyJelatineList[page]);
        pageTxt.text = string.Format("#{0:00}", page + 1);

        // SetNativeSize 스크립트로 로직 작성해야됨
    }

    
}
