using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolController : MonoBehaviour
{
    public GameObject symbolPrefab;
    private GameObject symbolObject;
    private RectTransform rewardPos;
    private float reelSpeed = 0;
    private float reelDamping = 2;
    private RectTransform disappearPos;
    private RectTransform respawanPos;
    private List<GameObject> symbolReel = new();
    private float symbolSpacing = 1f;
    private float topSymbolYPos = 2.0f;
    private float disappearSymbolYPos = -3.0f;
    private bool isRolling = false;
    private void Start()
    {
        CreateSymbol();
        GameEvent.Instance.OnSpinTriggered += SpinSymbolReel;
    }
    private void Update()
    {
        SymbolRollDown();
        SymbolSlowToStop();
    }
    private void OnDestroy()
    {
        GameEvent.Instance.OnSpinTriggered -= SpinSymbolReel;
    }
    public void CreateSymbol()
    {
        Vector2 symbolPosision = new(transform.position.x, transform.position.y + topSymbolYPos);
        for (int i = 0; i < 5; i++)
        {
            GameObject symbolObject = Instantiate(symbolPrefab, symbolPosision, Quaternion.identity, transform);
            symbolObject.GetComponent<Symbol>().SetupSymbol(Random.Range(0, 8));
            symbolReel.Add(symbolObject);
            symbolPosision.y -= symbolSpacing;
            //Debug.Log("symbolReel: " + symbolObject.GetComponent<Symbol>().symbolName);
            //Debug.Log("symbolPosision(Y): " + symbolPosision.y);
        }
        //foreach (GameObject symbolObject in symbolReel)
        //{
        //    Debug.Log("Symbol is Y posision" + symbolObject.GetComponent<Symbol>().symbolName
        //        + " : " + symbolObject.transform.position.y);
        //}
    }
    public void SpinSymbolReel()
    {
        Debug.Log("SpinSymbolReel()");
        isRolling = true;
        reelSpeed = 10f;
        //抓取symbolReel中的每一個物件的RectTransform
        foreach (GameObject symbolObject in symbolReel)
        {
            Debug.Log("Symbol is Y posision" + symbolObject.GetComponent<Symbol>().symbolName
                + " : " + symbolObject.transform.position.y);
        }
        //將每一個物件獲得一個向下20的速度，每秒速度減少0.1
        //若有物件的Y座標小於-2的Y座標時，則該物件的Y座標設為 +2 的Y座標
        //當速度<=0時，速度等於0，則物件Y座標最接近0的物件A，其他的物件加上物件A的Y座標值，物件A的Y座標設為0
        //Y座標為0的物件為獎勵位置
    }
    void SymbolRollDown()
    {
        if (isRolling)
        {
            foreach (GameObject symbol in symbolReel)
            {
                symbol.transform.position = new Vector2(symbol.transform.position.x, symbol.transform.position.y - reelSpeed * Time.deltaTime);
                if (symbol.transform.position.y <= transform.position.y + disappearSymbolYPos)
                {
                    symbol.transform.position = new Vector2(symbol.transform.position.x, transform.position.y + topSymbolYPos);
                }
            }
        }
        AdjustSymbolSpacing();
        //Debug.Log("RollDown : " + symbol.GetComponent<Symbol>().symbolName);   
    }
    void AdjustSymbolSpacing()
    {
        symbolReel.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
        for (int i = 0; i < symbolReel.Count - 1; i++)
        {
            GameObject currentSymbol = symbolReel[i];
            GameObject nextSymbol = symbolReel[i + 1];
            if (currentSymbol.transform.position.y - nextSymbol.transform.position.y < symbolSpacing)
            {
                nextSymbol.transform.position = new Vector2(nextSymbol.transform.position.x, currentSymbol.transform.position.y + symbolSpacing);
            }
        }
    }
    //滾動減速
    void SymbolSlowToStop()
    {
        if (reelSpeed > 0)
        {
            reelSpeed -= reelDamping * Time.deltaTime;
        }
        else if (reelSpeed <= 0)
        {
            reelSpeed = 0.0f; //0.05f
            isRolling = false;
            ResetSymbolPosision();
        }
    }
    void ResetSymbolPosision()
    {
        float symbolDistance = 0.0f;
        symbolReel.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));
        for (int i = 0; i< symbolReel.Count;i++)
        {
            symbolReel[i].transform.position = new Vector2(symbolReel[i].transform.position.x, transform.position.y + topSymbolYPos + symbolDistance);
            symbolDistance -= symbolSpacing;
        }
    }
}
    //IEnumerator ResetPos(float stopAdjust,float speed)
    //{
    //    while(isRolling)
    //    yield return null;
    //}
    //亂數生成SymbolPrefab中的資訊並配置位置
    //定義獎勵位置
    //滾動卷軸
    //傳出獎勵位置的資訊

