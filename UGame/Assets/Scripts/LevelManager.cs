using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int targetFrameRate = 60;
    public int targetLevelComplete;
    public int startingLevels;
    public float placementOffset;
    
    private static int _levelsComplete;
    
    private float _frameTime;
    private float _prevFrameTime;
    
    // Start is called before the first frame update
    protected void Init() {
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public float GetFrameTime() {
        return _frameTime;
    }

    public void LevelComplete() {
        _levelsComplete++;
        Debug.Log("Levels Complete: " + _levelsComplete);
        
        if (_levelsComplete == targetLevelComplete) {
            _levelsComplete = 0;
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected IEnumerator FrameTime() {
        while (SceneManager.GetActiveScene().isLoaded) {
            yield return new WaitForEndOfFrame();
            
            _frameTime = Time.time - _prevFrameTime;
            _prevFrameTime = Time.time;
        }
    }

    protected virtual void GenerateLevel() { }

    protected List<Vector3> GenerateRoomLocations(int chamberCount) {
        List<Vector3> locations = new List<Vector3>();
        
        double rowsCols = Math.Sqrt(chamberCount);
        
        // Is the Chamber count valid?
        if((chamberCount % rowsCols) != 0) {
            Debug.Log("Level generation failed.  Please enter a Square Integer for Chamber count.");
        } else {
            // Create the room spawn points
            for (int i = 0; i < rowsCols; i++) {
                for (int j = 0; j < rowsCols; j++) {
                    float posX = placementOffset * -j;
                    float posY = 0;
                    float posZ = placementOffset * -i;

                    locations.Add(new Vector3(posX, posY, posZ));
                }
            }
        }

        return locations;
    }
}
