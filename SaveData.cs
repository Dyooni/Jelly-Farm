using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int[] jellyUnlockList = new int[12];

    public float jelatine;
    public float gold;

    public void Save()
    {
        PlayerPrefs.SetFloat("Jelatine", jelatine);
        PlayerPrefs.SetFloat("Gold", gold);

        for (int i = 0; i < jellyUnlockList.Length; i++) {
            PlayerPrefs.SetInt($"JellyUnlock{i}", jellyUnlockList[i]);
        }
    }

    public void Load()
    {
        jelatine = PlayerPrefs.GetFloat("Jelatine", 100);
        gold = PlayerPrefs.GetFloat("Gold", 200);

        for (int i = 0; i < jellyUnlockList.Length; i++) {
            jellyUnlockList[i] = PlayerPrefs.GetInt($"JellyUnlock{i}");
        }
    }
}
