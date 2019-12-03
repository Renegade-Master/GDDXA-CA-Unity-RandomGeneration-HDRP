namespace Levels.Level_01 {
    using System.Collections.Generic;
    using UnityEngine;

    public class MngrLevel01 : LevelManager {
        public List<GameObject> chambers;
        public GameObject victoryCube;

        private List<Vector3> _roomLocations;
        private System.Random random;

        // Start is called before the first frame update
        void Start() {
            Init();
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(FrameTime());
            random = new System.Random();

            GenerateLevel();
            ChooseDestination();
        }

        // Update is called once per frame
        void Update() {

        }

        /**
         * Randomly place the Chambers to form the Maze 
         */
        protected override void GenerateLevel() {
            // Determine where to spawn the rooms
            _roomLocations = GenerateRoomLocations(startingLevels);

            foreach (var coordinate in _roomLocations) {
                var roomType = random.Next(chambers.Count);
                Instantiate(chambers[roomType], coordinate, chambers[roomType].transform.rotation);
            }
        }

        /**
         * Randomly choose a destination Chamber
         */
        void ChooseDestination() {
            int destination = random.Next(_roomLocations.Count);

            Instantiate(victoryCube, _roomLocations[destination], victoryCube.transform.rotation);
        }
    }
}