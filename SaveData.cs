using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public int[] jellyUnlockList = new int[12];
    
    public float jelatine;
    public float gold;

    public float sfx = 0.5f;
    public float bgm = 0.5f;

    public int numLevel;
    public int clickLevel;

    public bool isClear;
    int isClearNum;

    public GameObject jelly;
    public Animator jellyAnim;

    public void Save()
    {
        isClearNum = isClear ? 1 : 0;

        PlayerPrefs.SetFloat("Jelatine", jelatine);
        PlayerPrefs.SetFloat("Gold", gold);
        PlayerPrefs.SetInt("JellyList", GameManager.instance.jellyList.Count);
        PlayerPrefs.SetInt("JellyCount", GameManager.instance.jellyGroup.n);
        PlayerPrefs.SetInt("NumLevel", numLevel);
        PlayerPrefs.SetInt("ClickLevel", clickLevel);
        PlayerPrefs.SetFloat("BgmVolume", bgm);
        PlayerPrefs.SetFloat("SfxVolume", sfx);
        PlayerPrefs.SetInt("IsClear", isClearNum);

        for (int i = 0; i < jellyUnlockList.Length; i++) {
            PlayerPrefs.SetInt($"JellyUnlock{i}", jellyUnlockList[i]);
        }

        for (int i = 0; i < GameManager.instance.jellyList.Count; i++) {
            PlayerPrefs.SetInt($"JellyId{i}", GameManager.instance.jellyId[i]);
            PlayerPrefs.SetInt($"JellyLevel{i}", GameManager.instance.jellyLevel[i]);
            PlayerPrefs.SetFloat($"JellyExp{i}", GameManager.instance.jellyExp[i]);
            PlayerPrefs.SetInt($"JellyName{i}", GameManager.instance.jellyName[i]);
        }
    }

    public void Load()
    {
        jelatine = PlayerPrefs.GetFloat("Jelatine", 100);
        gold = PlayerPrefs.GetFloat("Gold", 200);
        numLevel = PlayerPrefs.GetInt("NumLevel", 1);
        clickLevel = PlayerPrefs.GetInt("ClickLevel", 1);
        bgm = PlayerPrefs.GetFloat("BgmVolume", 0.5f);
        sfx = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
        GameManager.instance.jellyGroup.n = PlayerPrefs.GetInt("JellyCount", 0);
        isClear = PlayerPrefs.GetInt("IsClear", 0) == 1;

        for (int i = 0; i < jellyUnlockList.Length; i++) {
            jellyUnlockList[i] = PlayerPrefs.GetInt($"JellyUnlock{i}");
        }

        for (int i = 0; i < PlayerPrefs.GetInt("JellyList", 0); i++) {
            GameManager.instance.jellyList.Add(jelly);
            GameManager.instance.jellyGroup.clone = Instantiate(jelly, GameManager.instance.jellyGroup.transform);
            GameManager.instance.jellyName.Add(PlayerPrefs.GetInt($"JellyName{i}"));
            GameManager.instance.jellyGroup.clone.name = $"{GameManager.instance.jellyName[i]}";
            GameManager.instance.jellyId.Add(PlayerPrefs.GetInt($"JellyId{i}"));
            GameManager.instance.jellyLevel.Add(PlayerPrefs.GetInt($"JellyLevel{i}"));
            GameManager.instance.jellyExp.Add(PlayerPrefs.GetFloat($"JellyExp{i}"));
            GameManager.instance.jelly.id = GameManager.instance.jellyId[i];
            GameManager.instance.jellyGroup.jellySprite.sprite = GameManager.instance.jellySpriteList[GameManager.instance.jelly.id];
            GameManager.instance.jelly.level = GameManager.instance.jellyLevel[i];
            GameManager.instance.ChangeAc(jellyAnim, GameManager.instance.jelly.level);
            GameManager.instance.jelly.exp = GameManager.instance.jellyExp[i];
        }
    }
}
