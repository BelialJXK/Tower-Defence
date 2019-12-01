using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject target = null;
    private float times;

    void Start()
    {
        times = 0;
    }

    void Update()
    {
        times += Time.deltaTime;
        if (times <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
        Attack();
    }

    private void Attack()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 0.5f) //if bullet and target close less than 0.5f
            {  
                //扣血，清除子弹，
                //target.hp-=xxx;
                Destroy(gameObject);
            }
        }
        else
        {   
            //destroy it self if no one to attack
            Destroy(gameObject);
        }
    }
}
