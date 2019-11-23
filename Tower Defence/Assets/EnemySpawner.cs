using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using  UnityEngine.AI;  



/// <summary>
/// 敌人生成控制脚本
/// </summary>
public class EnemySpawner : MonoBehaviour
{

    //属性面板
    public Wave[] Waves;

    //生成位置
    public Transform StartTran;

    //孵化间隔
    public float WaveRate = 0.2f;

    //存活敌人的数量
    public static int CountEnemyAlive = 0;

    private Coroutine coroutine;


    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }


    /// <summary>
    /// 敌人孵化器
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemy()
    {
        //遍历所有Waves中的 数组
        foreach (Wave wave in Waves)
        {
            for (int i = 0; i < wave.Count; i++)
            {
                //实例化预设物（每一波敌人的预设物，开始位置，无旋转的）旋转前的初始角
                GameObject.Instantiate(wave.EnemyPrefab, StartTran.position, Quaternion.identity);

                CountEnemyAlive++; //存活数量增加

                if (i != wave.Count - 1) //检测生成是否完毕
                {
                    //时间间隔
                    yield return new WaitForSeconds(wave.Rate);
                }
            }

            //当存活数量大于0
            while (CountEnemyAlive > 0)
            {
                yield return 0; //暂停0帧，不执行下边代码
            }

            //每一波暂停 WaveRate 秒
            yield return new WaitForSeconds(WaveRate);
        }
    }


    /// <summary>
    /// 停止生成
    /// </summary>
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
}
/// <summary>
/// 保存每一波敌人生成所需要的属性
/// </summary>
[System.Serializable] //可以被序列化的属性
public class Wave
{
    public GameObject EnemyPrefab; //敌人
    public int Count;       //数量
    public float Rate;        //时间间隔
}