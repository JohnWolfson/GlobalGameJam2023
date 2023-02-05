using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstLevel : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
