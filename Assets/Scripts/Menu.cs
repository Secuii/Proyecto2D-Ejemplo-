using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu = null;
    [SerializeField] private GameObject MainMenu = null;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettings()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void BackButton()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

