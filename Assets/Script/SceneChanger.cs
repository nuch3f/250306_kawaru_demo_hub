using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void GoStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void GoIngameScene()
    {
        SceneManager.LoadScene("Ingame");
    }
    public void GoTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
