using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Application.loadedLevel == 0)
                Application.LoadLevel("第5題");
            
            else if (Application.loadedLevel == 1)
                Application.LoadLevel("第1題");

            else if (Application.loadedLevel == 2)
                Application.LoadLevel("第2題");

            else if (Application.loadedLevel == 3)
                Application.LoadLevel("第3題");

            else if (Application.loadedLevel == 4)
                Application.LoadLevel("第4題");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Application.loadedLevel == 0)
                Application.LoadLevel("第2題");

            else if (Application.loadedLevel == 1)
                Application.LoadLevel("第3題");

            else if (Application.loadedLevel == 2)
                Application.LoadLevel("第4題");

            else if (Application.loadedLevel == 3)
                Application.LoadLevel("第5題");

            else if (Application.loadedLevel == 4)
                Application.LoadLevel("第1題");
        }


    }
}    
