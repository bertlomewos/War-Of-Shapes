using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manage_Game_system : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void load(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void quite()
    {
        Application.Quit();
    }
}
