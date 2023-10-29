using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_Text nickName;

    [SerializeField] public GameObject exitConfirmation;
    [SerializeField] public GameObject mapChoise;

    private void Start()
    {
        PlayerPrefs.GetString("nickName");
    }

    public void PlayLegacy()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayCoreWood()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayPlains()
    {
        SceneManager.LoadScene(3);
    }

    public void MapChoise()
    {
        mapChoise.SetActive(true);
    }

    public void ExitConfirmation()
    {
        PlayerPrefs.SetString("nickName", nickName.ToString());
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
