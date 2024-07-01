using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{


    public void loadscene(int index)
    {
        SceneManager.LoadScene(index);
    }
  


    public void exist()
    {
        Application.Quit();
    }
}
