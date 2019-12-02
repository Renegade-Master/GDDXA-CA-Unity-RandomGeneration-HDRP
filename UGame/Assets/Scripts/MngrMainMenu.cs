using System.Collections;
using UnityEngine;

public enum MainMenuOption {
    START_GAME,
    SETTINGS,
    QUIT
}

public class MngrMainMenu : LevelManager {

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FrameTime());
    }

    // Update is called once per frame
    void Update() {
        
    }
}
