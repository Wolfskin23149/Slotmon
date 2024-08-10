using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineSystem : MonoBehaviour
{
    public static SlotMachineSystem Instance => _instance;
    private static SlotMachineSystem _instance = null;
    public string[,] rewardAmount = new string[3,3];
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ShowReward()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log("rewardAmount[" + (i+1) + "," + (j+1) + "]: " + rewardAmount[i, j]);
            }
        }
    }
}
