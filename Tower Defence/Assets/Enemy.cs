using UnityEngine;
using System.Collections;
using UnityEngine.UI;




/// <summary>
/// 敌人脚本
/// </summary>
public class Enemy : MonoBehaviour
{



    //速度
    private float Speed = 10;

    private int Hp = 150;

    public void TakeDamage(int damage)
    {
        if (Hp <= 0) return;                    //死了不处理
        Hp -= damage;               //减少血量
     }

    public float getHP()
    {
        return Hp;
    }

    public void modifHP(int dmg)
    {
        Hp -= dmg;
    }
    public float getSpeed()
    {
        return Speed;
    }

    public void modifSpeed(float slow)
    {
        Speed += slow;
    }


}

