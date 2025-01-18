using UnityEngine;

public class JellyGroup : MonoBehaviour
{
    public bool isLive;
    public GameObject jelly;
    public GameObject clone;
    public Jelly child;

    public SpriteRenderer jellySprite;

    public void BuySuccess()
    {
        SetJellyData();
        clone = Instantiate(jelly, transform);
        isLive = false;
        GameManager.instance.jellyList.Add(jelly);
        GameManager.instance.jellyId.Add(GameManager.instance.jelly.id);
        GameManager.instance.jellyLevel.Add(GameManager.instance.jelly.level);
        GameManager.instance.jellyExp.Add(GameManager.instance.jelly.exp);
        clone.name = $"{GameManager.instance.jellyList.Count - 1}";
    }

    public void SetJellyData()
    {
        GameManager.instance.jelly.id = GameManager.instance.jellyPanel.page;
        GameManager.instance.jelly.level = 1;
        GameManager.instance.jelly.exp = 0;
        GameManager.instance.jelly.transform.position = GameManager.instance.pointList[Random.Range(0, GameManager.instance.pointList.Length)];

        jellySprite.sprite = GameManager.instance.jellySpriteList[GameManager.instance.jelly.id];
    }
}
