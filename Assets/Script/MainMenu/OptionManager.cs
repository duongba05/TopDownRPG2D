using Unity.VisualScripting;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject _optionMenu;
    public void Volume()
    {

    }
    public void Quit()
    {
        _mainMenu.SetActive(true);
        _optionMenu.SetActive(false);
    }
}
