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
    private enum SymbolName { Fire, Water, Wind, Dark, Light, Food, Coin, Wild, Enemy };//�W�٤������B���B���B�t�B���B�����B�����B�ĤH�B�ʷf
    private enum SymbolType { Growth, Food, Coin };//�������������귽�B�����B����
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
