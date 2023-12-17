using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text liaotianPanel;

    public GameObject yesBtn;

    private bool yesIsShow;
    private bool isFirst;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            isFirst = !isFirst;
        if (isFirst)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (SceneManager.GetActiveScene().name=="Scene0")
        {
            ShowYesBen("Now, Sebastian, my brave adventurer, are you ready to embark on this mysterious journey?");
        }
        else if(SceneManager.GetActiveScene().name == "Scene1")
        {
            ShowYesBen("Mission: Fish out a boot from the pond.");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(SceneManager.GetActiveScene().name=="Scene2")
        {
            ShowYesBen("Mission: Rescue the kitten.");
        }
        else if (SceneManager.GetActiveScene().name == "Scene3")
        {
            ShowYesBen("Mission: Collect luminescent tree leaves.");
        }
        else if (SceneManager.GetActiveScene().name == "Scene4")
        {
            ShowYesBen("Mission: Retrieve the lost red scarf.");
        }
        else if (SceneManager.GetActiveScene().name == "Scene5")
        {
            ShowYesBen("Sebastian, congratulations! You have obtained the treasure!");
        }


        
    }

    void ShowYesBen(string n)
    {
        if (!yesIsShow && liaotianPanel.text == n)
        {
            yesBtn.SetActive(true);
            yesIsShow = true;
            
        }
    }


}
