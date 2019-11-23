using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private GameObject selectPanel;
    // Start is called before the first frame update
    void Start()
    {
        selectPanel = transform.Find("SelectCanvas").gameObject; // 捕捉名为SelectCanvas的画布
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
        if(Physics.Raycast(ray, out hit, 50))
        {
            if(hit.transform.tag =="TowerBase") //点击带有TowerBase的砖块
            {
                ShowSelectPanel(hit.transform);
            }
        }
    }

    private void ShowSelectPanel(Transform pos)
    {
        selectPanel.transform.SetParent(pos, false);
        selectPanel.SetActive(true);
    }


}
