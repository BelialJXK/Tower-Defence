using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_map_1 : MonoBehaviour {

    public Button Back;
    void Start()
    {
        Back.onClick.AddListener(mainmenu);
        Cursor.visible = true;
    }

    private void mainmenu()
    {
        SceneManager.LoadScene("Start_menu");
    }
}
