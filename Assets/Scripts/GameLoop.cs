using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Game Initialization
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input
        //GameLogic Update
        //UI Update
    }
}
