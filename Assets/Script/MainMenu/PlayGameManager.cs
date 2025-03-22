using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayGameManager : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject _optionMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsGame()
    {
        _mainMenu.SetActive(false);
        _optionMenu.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
