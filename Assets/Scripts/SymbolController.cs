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
        //���symbolReel�����C�@�Ӫ���RectTransform
        foreach (GameObject symbolObject in symbolReel)
        {
            Debug.Log("Symbol is Y posision" + symbolObject.GetComponent<Symbol>().symbolName
                + " : " + symbolObject.transform.position.y);
        }
        //�N�C�@�Ӫ�����o�@�ӦV�U20���t�סA�C��t�״��0.1
        //�Y������Y�y�Фp��-2��Y�y�ЮɡA�h�Ӫ���Y�y�г]�� +2 ��Y�y��
        //��t��<=0�ɡA�t�׵���0�A�h����Y�y�г̱���0������A�A��L������[�W����A��Y�y�ЭȡA����A��Y�y�г]��0
        //Y�y�Ь�0�����󬰼��y��m
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
    //�u�ʴ�t
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
    //�üƥͦ�SymbolPrefab������T�ðt�m��m
    //�w�q���y��m
    //�u�ʨ��b
    //�ǥX���y��m����T

