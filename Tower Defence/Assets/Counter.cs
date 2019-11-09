using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //public GameObject ti;
    //public GameObject ni;
    //int end = 1;
    //int DownTime = 6;

    public Text TowerText;
    public float Tower;
    
    // Start is called before the first frame update
    void Start()
    {
        //ni = GameObject.Find("nice");
        //ti = GameObject.Find("time");
    }

    // Update is called once per frame
    void Update()
    {
        //if (end > 0)
        //{
        //    end = DownTime - (int)Time.time;
        //    ni.GetComponent<Text>().text = "" + end;
        //}

        //if (end == 0)
        //{
        //    ti.GetComponent<Text>().text = "Time Up";
        //}
    }

    public void CounterTower()
    {
        Tower += 1;
        TowerText.text = Tower.ToString();
        //计算塔的数目可以将变量hp声明为全局变量，多个函数调用即可
    }
}
