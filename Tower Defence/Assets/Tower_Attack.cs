using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Attake : MonoBehaviour
{   [HideInInspector]
    public List<GameObject> enemy; //which can be attack
    private GameObject targetObject;//攻击目标
    private float dis;
    private Transform head;//可旋转部位
    private float attack_CD;
    private GameObject bulletPrefab;
    private Transform firePos;

    void Start()
    {
        attack_CD = 0;
        dis = 100;
        enemy = new List<GameObject>();
        targetObject = null;
        head = transform.GetChild(1);
        firePos = head.GetChild(0);
        bulletPrefab = Resources.Load<GameObject>("Assets/Stuff/bullet1");
    }


    void Update()
    {
        if (enemy.Count > 0)
        {
            if (targetObject == null)
            {
                //choose target
                targetObject= SelectTarget();
            }
        }
        //attack
        if (targetObject != null)
        {
            LookTarget();
            //消除怪，加金币，减怪总数
            /*if (target.HP <= 0)
            {   
                Destroy(target);
                enemy.Remove(other.gameObject);
                gold += xxx;
                enems -= xxx;
            }*/

        }
    }

    //Check is monster into attack range?
    public void CheckInto(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!enemy.Contains(other.gameObject))
            {
                enemy.Add(other.gameObject);
            }
        }
    }

    //check is monster leave attack range
    public void CheckLeave(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (targetObject != null && other.name == targetObject.name)
            {
                    targetObject = null;
            }
            if (enemy.Contains(other.gameObject))
            {              
                enemy.Remove(other.gameObject);
            }
        }
    }

    private GameObject SelectTarget()
    {
        GameObject temp = null;
        float distance = 0;
        //use loop to find min distance between tower and enemy
        for (int i = 0; i < enemy.Count; i++)
        {
            distance = Vector3.Distance(transform.position, enemy[i].transform.position);
            if (distance <= dis)
            {
                dis = distance;
                temp = enemy[i];
            }
        }
        return temp;
    }

    private void LookTarget()
    {
        Vector3 pos = targetObject.transform.position;
        pos.y = head.position.y;//to make sure it will not look up or down
        head.LookAt(pos);//follow enemies Rotate
        attack_CD += Time.deltaTime;
        if (attack_CD >= 1)//1s cd
        {
            //Attack
            Attack();
            attack_CD = 0;
        }
    }

    private void Attack()
    {
        GameObject bullets = Instantiate(bulletPrefab, firePos.position,Quaternion.identity);
        //add bullet script
        bullets.AddComponent<BulletMove>().target=targetObject;
        bullets.transform.LookAt(targetObject.transform.position);

    }
}
