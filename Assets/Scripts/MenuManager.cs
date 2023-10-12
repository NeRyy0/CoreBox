using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject exitConfirmation;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitConfirmation()
    {
        exitConfirmation.SetActive(true);
    }

    public void NExitConfirmation()
    {
        exitConfirmation.SetActive(false);
    }

    public void YExitConfirmation()
    {
        Application.Quit();
    }
}
