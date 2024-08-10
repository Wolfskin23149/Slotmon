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
    private float reelDamping = 10;
    private RectTransform disappearPos;
    private RectTransform respawanPos;
    private List<GameObject> symbolReel = new();
    private float symbolSpacing = 1f;
    private float topSymbolYPos = 2.0f;
    private float disappearSymbolYPos = -3.0f;
    private bool isRolling = false;
    public List<string> rewardArea = new();
    private void Start()
    {
        CreateSymbol();
        GameEvent.Instance.OnSpinTriggered += SpinSymbolReel;
        GameEvent.Instance.OnSpinCompleted += SetRewardArea;
    }
    private void Update()
    {
        SymbolRollDown();
        SymbolSlowToStop();
    }
    private void OnDestroy()
    {
        GameEvent.Instance.OnSpinTriggered -= SpinSymbolReel;
        GameEvent.Instance.OnSpinCompleted -= SetRewardArea;
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
        reelSpeed = 50f;
        //���symbolReel�����C�@�Ӫ���RectTransform
        foreach (GameObject symbolObject in symbolReel)
        {
            Debug.Log("Symbol is Y posision" + symbolObject.GetComponent<Symbol>().symbolName
                + " : " + symbolObject.transform.position.y);
            Debug.Log("Symbol is X posision" + symbolObject.GetComponent<Symbol>().symbolName
                + " : " + symbolObject.transform.position.x);
        }
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
        else if (reelSpeed <= 0.05f && isRolling)
        {
            reelSpeed = 0; //0.05f
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
        GameEvent.Instance.SpinCompleted();
    }
    //�ǥX���y��m����T
    //��m�bY�b�W 1�B0�B-1�y�ФW���Ÿ��A�����y�Ÿ�
    void SetRewardArea()
    {
        rewardArea.Clear();
        for (int i = 0; i < symbolReel.Count; i++)
        {
            if (symbolReel[i].transform.position.y <= 1 && symbolReel[i].transform.position.y >= -1)
            {
                string rewardSymbol = symbolReel[i].GetComponent<Symbol>().symbolName;
                rewardArea.Add(rewardSymbol);
                SendToAmount();
            }
        }
    }
    void SendToAmount()
    {
        float reelList = symbolReel[0].transform.position.x;
        if (reelList <= -1)
        {
            for (int i = 0; i < rewardArea.Count; i++)
            {
                SlotMachineSystem.Instance.rewardAmount[0, i] = rewardArea[i];
            }
        }
        else if (reelList == 0)
        {
            for (int i = 0; i < rewardArea.Count; i++)
            {
                SlotMachineSystem.Instance.rewardAmount[1, i] = rewardArea[i];
            }
        }
        else if (reelList >= 1)
        {
            for (int i = 0; i < rewardArea.Count; i++)
            {
                SlotMachineSystem.Instance.rewardAmount[2, i] = rewardArea[i];
            }
        }
    }
}

