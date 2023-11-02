using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public string Level1;
    public void OnPlay()
    {
        SceneManager.LoadScene(Level1);
    }
    public void Credits()
    {
        
    }
    public void Settings()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
