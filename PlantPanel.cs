using UnityEngine;
using UnityEngine.UI;

public class PlantPanel : MonoBehaviour
{
    public Text numSubText;
    public Text numBtnText;
    public Text clickSubText;
    public Text clickBtnText;

    public GameObject numButton;
    public GameObject clickButton;

    void Update()
    {
        numSubText.text = $"젤리 수용량 {GameManager.instance.saveData.numLevel * 2}";
        clickSubText.text = $"젤리 생산량 {GameManager.instance.saveData.clickLevel}";
        numBtnText.text = string.Format("{0:n0}", GameManager.instance.numGoldList[GameManager.instance.saveData.numLevel]);
        clickBtnText.text = string.Format("{0:n0}", GameManager.instance.clickGoldList[GameManager.instance.saveData.clickLevel]);
        ActiveButton();
    }

    public void NumCheck()
    {
        if (GameManager.instance.goldValue >= GameManager.instance.numGoldList[GameManager.instance.saveData.numLevel]) {
            GameManager.instance.saveData.gold -= GameManager.instance.numGoldList[GameManager.instance.saveData.numLevel];
            GameManager.instance.saveData.numLevel++;
        }
        else {
            GameManager.instance.soundManager.PlaySfx(3);
        }
    }

    public void ClickCheck()
    {
        if (GameManager.instance.goldValue >= GameManager.instance.clickGoldList[GameManager.instance.saveData.clickLevel]) {
            GameManager.instance.saveData.gold -= GameManager.instance.clickGoldList[GameManager.instance.saveData.clickLevel];
            GameManager.instance.saveData.clickLevel++;
        }
        else {
            GameManager.instance.soundManager.PlaySfx(3);
        }
    }
    

    void ActiveButton()
    {
        if (GameManager.instance.saveData.numLevel < 5) {
            numButton.SetActive(true);
        }
        else {
            numButton.SetActive(false);
        }
        
        if (GameManager.instance.saveData.clickLevel < 5) {
            clickButton.SetActive(true);
        }
        else {
            clickButton.SetActive(false);
        }
    }
}
