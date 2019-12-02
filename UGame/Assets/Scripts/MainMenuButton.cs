using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour {
    public MainMenuOption menuOption;
    
    private Button _button;
    private MngrMainMenu _manager;

    private void Start()
    {
        _button = GetComponent<Button>();
        Debug.Log("Initialising new Button: " + _button.name);
        
        _button.onClick.AddListener(LaunchSelection);
    }

    private void LaunchSelection() {
        Debug.Log("Button " + _button.name + " was pressed.");
        switch (menuOption) {
            case MainMenuOption.START_GAME:
                break;
            case MainMenuOption.SETTINGS:
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