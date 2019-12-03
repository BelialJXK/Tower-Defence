using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map6_monsterComing : MonoBehaviour
{
    public GameObject monster;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    private float time = 10f;
    private int many = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && many > 0)
        {
            for (int y = 0; y < 3; y++)
            {
                createMon(-19.8f, 4.5f, -10.1f, monster);
                createMon(-19.8f, 4.5f, 6f, monster1);
                createMon(15.9f, 4.5f, -13.6f, monster2);
                createMon(16.8f, 4.5f, 14.8f, monster3);
            }
            time = 10f;
            many -= 1;
        }
    }

    public void waitTime(float t)
    {
        float times = 10f;
        if (times < 0)
        {
            return;
        }
        else
        {
            t -= Time.deltaTime;
        }
    }

    public void createMon(float x, float y, float z, GameObject mon)
    {
        GameObject obj = (GameObject)Instantiate(mon);
        obj.transform.position = new Vector3(x, y, z);
    }
}
