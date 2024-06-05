using System;
using UnityEngine;
using UnityEngine.UI;

public class UIHeart : NewMonoBehaviour
{
    [SerializeField] private Sprite _empty;
    [SerializeField] private Sprite _full;

    private void OnEnable()
    {
        UIHeartOsv.CreatUIHeart += CreatUIHeart;
        UIHeartOsv.UpdateHp += UpdateHp;
    }
    private void OnDisable()
    {
        UIHeartOsv.CreatUIHeart -= CreatUIHeart;
        UIHeartOsv.UpdateHp -= UpdateHp;
    }

    private void CreatUIHeart(int maxHP)
    {
        for (int i = 0; i < maxHP; i++)
        {
            GameObject newHeart = new GameObject("newHeart", typeof(RectTransform), typeof(Image));
            newHeart.transform.SetParent(transform, false);
            newHeart.transform.localScale = Vector3.one * 0.3f;
            newHeart.GetComponent<Image>().sprite = _full;
        }
    }
    private void UpdateHp(int currentHp)
    {
        for(int i = 0; i < transform.childCount; i++) 
        { 
            if(i < currentHp)
                transform.GetChild(i).GetComponent<Image>().sprite = _full;
            else
                transform.GetChild(i).GetComponent<Image>().sprite = _empty;
        }
    }
}
public static class UIHeartOsv
{
    public static Action<int> CreatUIHeart;
    public static Action<int> UpdateHp;
}
