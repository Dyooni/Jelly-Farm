using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float jelatineValue;
    float goldValue;
    public float jelatine;
    public float gold;

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

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        jelatineValue = PlayerPrefs.GetFloat("Jelatine", 0);
        goldValue = PlayerPrefs.GetFloat("Gold", 0);
    }

    void LateUpdate()
    {
        jelatineValue = Mathf.SmoothStep(jelatineValue, jelatine, 0.5f);
        goldValue = Mathf.SmoothStep(goldValue, gold, 0.5f);

        jelatineText.text = string.Format("{0:n0}", jelatineValue);
        goldText.text = string.Format("{0:n0}", goldValue);

        PlayerPrefs.SetFloat("Jelatine", jelatineValue);
        PlayerPrefs.SetFloat("Gold", goldValue);
    }

    public void ChangeAc(Animator anim, int level)
    {
        anim.runtimeAnimatorController = levelAc[level-1];
    }
}
