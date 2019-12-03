namespace MainMenu {
    using UnityEngine;
    using System.Collections.Generic;
    
    public enum MainMenuOption {
        START_GAME,
        SETTINGS,
        QUIT
    }

    public class MngrMainMenu : LevelManager {
        public List<GameObject> characters;
        
        private Vector2 noMovement = new Vector2(0.0f,0.0f);
        
        // Start is called before the first frame update
        void Start() {
            Init();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            
            StartCoroutine(FrameTime());
        }

        // Update is called once per frame
        void FixedUpdate() {
            System.Random random = new System.Random();
            
            foreach (GameObject character in characters) {
                int chance = random.Next(1024);
                
                if (chance < 2) {
                    character.GetComponent<PlayerController>().SetInput(noMovement, "AttackShoot");
                } else if (chance > 2 && chance < 7) {
                    character.GetComponent<PlayerController>().SetInput(noMovement, "Jump");
                } else if (chance > 7 && chance < 15) {
                    character.GetComponent<PlayerController>().SetInput(noMovement, "AttackSlash");
                }
            }
        }
    }
}