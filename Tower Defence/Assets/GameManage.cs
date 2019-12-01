using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManage : MonoBehaviour
{
    private GameObject selectPanel;         //小菜单1 直接建塔
    // Start is called before the first frame update
    private GameObject nextSelectPanel;     //小菜单2 Build Sell Cancel
    private GameObject firstPanel;          //获取小菜单1
    public GameObject[] towers;             //给GameManage中添加塔的数组以放置塔模型
    private GameObject selectTower;         //即将要创建的塔
    private Transform basePos;              //地基位置，塔的创建位置

    void Start()
    {
        //selectTower = null;
        selectPanel = transform.Find("SelectCanvas").gameObject; // 捕捉名为SelectCanvas的画布 第一个小菜单
        //nextSelectPanel = transform.Find("NextSelectPanel").gameObject; //第二个小菜单


        firstPanel = selectPanel.transform.GetChild(0).gameObject;
        nextSelectPanel = selectPanel.transform.GetChild(1).gameObject;

        Debug.Log(selectPanel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBase();
        }
    }

    private void SelectBase() //选择创建塔的砖块
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 50) && EventSystem.current.IsPointerOverGameObject() ==false)
        {                                        //↑并且射线没有点击到UI才执行
            
            if (hit.transform.tag =="TowerBase") //点击带有TowerBase的砖块
            {
                

                ShowSelectPanel(hit.transform);
               

                basePos = hit.transform; //把地基的局部变量传出来
                

            }
        }
    }

    private void ShowSelectPanel(Transform pos)
    {
        

        selectPanel.transform.SetParent(pos, false);
                 
        selectPanel.transform.localPosition = new Vector3(0, 0, 0);//小菜单位置

        selectPanel.SetActive(true);

    }

    public void SelecttowerOne(bool isOn) //选择第一个塔 下以此类推
    {
        if (isOn)
        {
            Debug.Log("SelecttowerOne");
            selectTower = towers[0];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerOTwo(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerTwo");
            selectTower = towers[1];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerThree(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerThree");
            selectTower = towers[2];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerFour(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerFour");
            selectTower = towers[3];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void CloseAll()      //关闭所有第一层)
    {
        selectPanel.SetActive(false);
        nextSelectPanel.SetActive(false);//防止第二层窗口开着
        firstPanel.SetActive(true);

    }

    public void CloseNext()     //第二次关闭
    {
        nextSelectPanel.SetActive(false);
        firstPanel.SetActive(true);

    }

    
    public void CreateTower()    //建塔
    {
        if (selectTower != null)
        {
            Debug.Log("Build");
            GameObject temperTower = Instantiate(selectTower);
            temperTower.transform.SetParent(basePos, false);
            temperTower.transform.localPosition = new Vector3(0, 0, 0);
            //temperTower.transform.localScale = new Vector3(1, 0.8F, 1); // 定义尺寸
                                                                        //在此处加 炮塔攻击脚本
            InitUI();

        }
    }

    public void SellTower()      //卖塔
    {
        Debug.Log("Sell");
        if(basePos.childCount >=2) //两个UI
        {
            Destroy(basePos.GetChild(0).gameObject);
            InitUI();
        }
        else
        {
            Debug.Log("目标地基没有炮台，无法建塔！");
        }
    }

    private void InitUI()       //初始化UI
    {
        selectTower = null;
        selectPanel.SetActive(false);
        firstPanel.SetActive(true);
        nextSelectPanel.SetActive(false);

    }
}
