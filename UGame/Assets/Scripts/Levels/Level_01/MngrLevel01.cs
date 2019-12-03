namespace Levels.Level_01 {
    using System.Collections.Generic;
    using UnityEngine;

    public class MngrLevel01 : LevelManager {
        public List<GameObject> chambers;

        // Start is called before the first frame update
        void Start() {
            StartCoroutine(FrameTime());

            GenerateLevel();
        }

        // Update is called once per frame
        void Update() {

        }

        /**
         * Randomly place the Chambers to form the Maze 
         */
        protected override void GenerateLevel() {
            base.GenerateLevel();
            Debug.Log("Congratulations, from Level 01 Manager");

            // Determine where to spawn the rooms
            List<Vector3> roomLocations = GenerateRoomLocations(startingLevels);

            foreach (var coordinate in roomLocations) {
                Debug.Log("Room location: " + coordinate);

                var roomType = 0;
                Instantiate(chambers[roomType], coordinate, chambers[roomType].transform.rotation);
            }
        }
    }
}