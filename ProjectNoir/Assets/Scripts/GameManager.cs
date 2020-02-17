using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject fow;
    private bool isActive = true;

    public GameObject[] lights;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            isActive = !isActive;
            fow.SetActive(isActive);
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            isActive = !isActive;
            for (int i = 0; i <lights.Length; i++)
            {
                lights[i].SetActive(isActive);
            }
        }
    }

}
