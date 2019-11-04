using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_menu : MonoBehaviour {

    public Button NewGame;
    public Button Introduction;
    public Button GameExit;

    void Start()
    {
        
        NewGame.onClick.AddListener(begin);
        Introduction.onClick.AddListener(Introduction_page);
        GameExit.onClick.AddListener(Exit);
        
    }

    private void Exit()
    {   Debug.Log("exit");
        Application.Quit();
    }

    private void Introduction_page()
    {
        SceneManager.LoadScene("Introduction_menu");
    }

    private void begin()
    {
        
        SceneManager.LoadScene("Game_map_1");
    }
}
