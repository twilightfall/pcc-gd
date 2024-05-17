using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private List<Button> ButtonGroup;

    private List<string> SceneNames = new();

    private void Awake()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            SceneNames.Add(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GoHome()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
