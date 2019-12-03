using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CounterDown : MonoBehaviour
{
    public GameObject ti;
    public GameObject ni;
    public int end = 1;
    private int TimeControl = 30; //若为public，Update函数不能调用
    //public bool ClickNum = false;


    // Start is called before the first frame update
    void Start()
    {
        ni = GameObject.Find("nice");
        ti = GameObject.Find("time");
    }

    // Update is called once per frame

    void Update()
    {
        //if (ClickNum == true)
        //{
            if (end > 0)
            {
                end = TimeControl - (int)Time.time;
                ni.GetComponent<Text>().text = "" + end;
            }

            if (end == 0)
            {
                ti.GetComponent<Text>().text = "Time up";
            }
        //}
    }
    //public void Click() 
    //{
        //ClickNum = true;
        
    //}
}
