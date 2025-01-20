using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoticManager : MonoBehaviour
{
    public Text messageText;
    public Image centerTextImg;
    public RectTransform centerText;

    public bool isNegative;

    public void Message(string select)
    {
        string messageContent;

        switch(select) {
            case "Start":
                messageContent = "모든 젤리를 해금하는 것이 목표.";
                break;
            case "Clear":
                messageContent = "모든 젤리를 해금했어요! 행복해 :)";
                break;
            case "Sell":
                messageContent = "젤리를 드래그해서 주머니에 놓아 팔 수 있어요.";
                break;
            case "NotJelatin":
                messageContent = "젤라틴이 부족합니다.";
                break;
            case "NotGold":
                messageContent = "골드가 부족합니다.";
                break;
            case "NotNum":
            default:
                messageContent = "젤리 수용량이 부족합니다.";
                break;
        }

        isNegative = select.Substring(0, 3) == "Not";
        messageText.text = messageContent;

        if (isNegative) {
            centerTextImg.color = new Color(255/255f, 98/255f, 98/255f);
            messageText.color = Color.white;
        }
        else if (!isNegative) {
            centerTextImg.color = new Color(0/255f, 200/255f, 255/255f);
            messageText.color = Color.black;
        }

        centerText.anchoredPosition = new Vector3(0, -3, 0);

        StartCoroutine(CloseWindow());
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSecondsRealtime(6);

        centerText.anchoredPosition = new Vector3(0, 20, 0);
    }
}
