using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float jelatineValue;
    public float goldValue;

    public Sprite[] jellySpriteList;
    public string[] jellyNameList;
    public int[] jellyJelatineList;
    public int[] jellyGoldList;
    public int[] numGoldList;
    public int[] clickGoldList;
    public Vector3[] pointList;
    
    public RuntimeAnimatorController[] levelAc;

    public Transform topLeft;
    public Transform bottomRight;
    public Text jelatineText;
    public Text goldText;

    public ClickSreen clickSreen;
    public JellyGroup jellyGroup;
    public Jelly jelly;
    public ButtonSell btnSell;
    public JellyButtonState jellyBtnState;
    public PlantButtonState plantBtnState;
    public JellyPanel jellyPanel;
    public SaveData saveData;
    public SoundManager soundManager;

    public List<int> jellyName = new List<int>();
    public List<GameObject> jellyList = new List<GameObject>();
    public List<int> jellyId = new List<int>();
    public List<int> jellyLevel = new List<int>();
    public List<int> jellyExp = new List<int>();

    void Awake()
    {
        instance = this;
        saveData.Load();
    }

    void LateUpdate()
    {
        jelatineValue = Mathf.SmoothStep(jelatineValue, saveData.jelatine, 0.5f);
        goldValue = Mathf.SmoothStep(goldValue, saveData.gold, 0.5f);

        jelatineText.text = string.Format("{0:n0}", jelatineValue);
        goldText.text = string.Format("{0:n0}", goldValue);

        saveData.Save();

        if (jellyName.Count < 1) {
            jellyGroup.n = 0;
        }
    }

    public void ChangeAc(Animator anim, int level)
    {
        anim.runtimeAnimatorController = levelAc[level-1];
    }
}
