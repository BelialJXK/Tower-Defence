using UnityEngine;
using System.Collections;
using UnityEngine.UI;




/// <summary>
/// 敌人脚本
/// </summary>
public class Enemy : MonoBehaviour
{
    //位置数组
    private Transform[] positions;

    //下标，从0开始
    private int index = 0;

    //速度
    public float Speed = 10;

    public float Hp = 150;

    private float TotalHp; //总HP

    public GameObject ExplosionEffect; //敌人爆炸特效

    private Slider HpSlider;


    /*void Start()
    {
        positions = WayPoints.positions;

        TotalHp = Hp;

        HpSlider = GetComponentInChildren<Slider>();
    }


    void Update()
    {
        Move();
    }*/


   /* void Move()
    {
        //下标越界，就跳出；
        if (index > positions.Length - 1) return;

        //找一个方向，（目标位置-当前位置）.normalized 取得这个向量的单位向量 ；
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * Speed);

        //判断 两点 之间的距离
        if (Vector3.Distance(positions[index].position, transform.position) < 0.5f)
        {
            index++;
        }


        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }
    */

    /// <summary>
    /// ReachDestination 到达 目的地 销毁
    /// </summary>
    /*void ReachDestination()
    {
        Destroy(this.gameObject);
        GameManager.instance.Failed();
    }*/


    /// <summary>
    /// 监听销毁敌人
    /// </summary>
   /* void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }
    */

    /// <summary>
    /// 敌人受到伤害
    /// </summary>
    /// <param name="damage"></param>
   public void TakeDamage(float damage)
    {
        if (Hp <= 0) return;                    //死了不处理
        Hp -= damage;               //减少血量
        HpSlider.value = (float)Hp / TotalHp; //血条
        if (Hp <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        GameObject effect = Instantiate(ExplosionEffect, transform.position, transform.rotation) as GameObject;

        Destroy(effect, 1.5f);

        Destroy(this.gameObject);
    }
}
/// <summary>
/// 路径导航脚本
/// </summary>
/*public class WayPoints : MonoBehaviour
{
    //拐点，数组
    public static Transform[] positions;


    void Awake()
    {
        //找到当前，挂载脚本物体下的，子物体数量
        positions = new Transform[transform.childCount];

        //依次遍历所有子物体，得到依次的位置
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}*/
