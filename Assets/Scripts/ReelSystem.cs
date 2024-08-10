//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.PlayerLoop;

//public class ReelSystem : MonoBehaviour
//{
//    //卷軸符號陣列
//    public List<Transform> symbolReel = new();
//    public GameObject symbolPrefab;
//    private Transform lastSymbol;
//    //卷軸動畫參數
//    private int indexResetPos;
//    private int indexMove;
//    public float speed = 0;
//    public float symbolSpacing = 1.0f;

//    private void Start()
//    {
//        InitReel();
//    }
//    /// <summary>
//    /// 初始化捲軸上的符號
//    /// </summary>
//    private void InitReel()
//    {
//        Vector3 symbolPosision = transform.position;

//        //清空卷軸符號陣列
//        symbolReel.Clear();
//        for (int i = 0; i < symbolReel.Count; i++)
//        {
//            symbolPrefab.GetComponent<Symbol>().symbolNumber = Random.Range(0, 9);
//            Instantiate(symbolPrefab, symbolPosision, Quaternion.identity, transform);
//            //隨機一個符號並加入卷軸符號陣列
//            symbolReel[i].position = symbolPosision;
//            symbolPosision.y += symbolSpacing;
//            //symbolReel.Add(transform.GetChild(i));
//        }

//        lastSymbol = symbolReel[symbolReel.Count - 1]; 
//    }
//    public Symbol CreateSymbol(int symbolNumber)
//    {
//        GameObject symbolObject = Instantiate(symbolPrefab);
//    }
//    //開始快速向下移動卷軸並逐漸減速，當卷軸移動到指定位置時，

//    //當卷軸停止時，檢查卷軸符號陣列中位於獎勵位置的符號，並傳出符號名稱
//}
