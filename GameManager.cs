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
    public Vector3[] pointList;
    
    public RuntimeAnimatorController[] levelAc;

    public Transform topLeft;
    public Transform bottomRight;
    public Text jelatineText;
    public Text goldText;

    public ClickSreen clickSreen;
    public Jelly jelly;
    public ButtonSell btnSell;
    public JellyButtonState jellyBtnState;
    public PlantButtonState plantBtnState;
    public SaveData saveData;

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        saveData.Load();
    }

    void LateUpdate()
    {
        jelatineValue = Mathf.SmoothStep(jelatineValue, saveData.jelatine, 0.5f);
        goldValue = Mathf.SmoothStep(goldValue, saveData.gold, 0.5f);

        jelatineText.text = string.Format("{0:n0}", jelatineValue);
        goldText.text = string.Format("{0:n0}", goldValue);

        saveData.Save();
    }

    public void ChangeAc(Animator anim, int level)
    {
        anim.runtimeAnimatorController = levelAc[level-1];
    }
}
