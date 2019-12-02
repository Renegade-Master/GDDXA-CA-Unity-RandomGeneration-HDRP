using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour {
    public MainMenuOption menuOption;
    
    private Button _button;
    private MngrMainMenu _manager;

    private void Start()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(LaunchSelection);
    }

    private void LaunchSelection() {
        switch (menuOption) {
            case MainMenuOption.START_GAME:
                SceneManager.LoadScene("Level_01");
                break;
            case MainMenuOption.SETTINGS:
                Debug.Log("No Settings yet, sorry ¯\\_(ツ)_/¯");
                break;
            case MainMenuOption.QUIT:
                Application.Quit();
                break;
        }
    }
    
    private void DebugButton() {
        Debug.Log("Button " + _button.name + " was pressed.");
    }
}