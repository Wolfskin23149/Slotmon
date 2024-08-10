using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Symbol :MonoBehaviour
{
    public List<Sprite> Images = new();
    public GameObject symbolPrefabe;
    private Sprite sourceImage;
    public string symbolName;
    private enum SymbolName { Fire, Water, Wind, Dark, Light, Food, Coin, Wild, Enemy };//名稱分為火、水、風、暗、光、食物、金幣、敵人、百搭
    private enum SymbolType { Growth, Food, Coin };//類型分為成長資源、食物、金幣
    public void SetupSymbol(int symbolNumber)
    {
        symbolName = ((SymbolName)symbolNumber).ToString();
        sourceImage = Images[symbolNumber];
        if (Images[symbolNumber] == null)
        {
            Debug.Log("Source Image is null.");
        }
        symbolPrefabe.GetComponent<Image>().sprite = sourceImage;
        Debug.Log("symbolName: " + symbolName);
        Debug.Log("sourceImage: " + sourceImage);
    }
}
