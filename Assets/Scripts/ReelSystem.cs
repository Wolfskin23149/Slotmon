//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.PlayerLoop;

//public class ReelSystem : MonoBehaviour
//{
//    //���b�Ÿ��}�C
//    public List<Transform> symbolReel = new();
//    public GameObject symbolPrefab;
//    private Transform lastSymbol;
//    //���b�ʵe�Ѽ�
//    private int indexResetPos;
//    private int indexMove;
//    public float speed = 0;
//    public float symbolSpacing = 1.0f;

//    private void Start()
//    {
//        InitReel();
//    }
//    /// <summary>
//    /// ��l�Ʊ��b�W���Ÿ�
//    /// </summary>
//    private void InitReel()
//    {
//        Vector3 symbolPosision = transform.position;

//        //�M�Ũ��b�Ÿ��}�C
//        symbolReel.Clear();
//        for (int i = 0; i < symbolReel.Count; i++)
//        {
//            symbolPrefab.GetComponent<Symbol>().symbolNumber = Random.Range(0, 9);
//            Instantiate(symbolPrefab, symbolPosision, Quaternion.identity, transform);
//            //�H���@�ӲŸ��å[�J���b�Ÿ��}�C
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
//    //�}�l�ֳt�V�U���ʨ��b�óv����t�A����b���ʨ���w��m�ɡA

//    //����b����ɡA�ˬd���b�Ÿ��}�C�������y��m���Ÿ��A�öǥX�Ÿ��W��
//}
