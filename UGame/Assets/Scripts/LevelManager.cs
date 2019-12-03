using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int targetFrameRate = 60;
    public int targetLevelComplete;
    public float placementOffset;
    
    protected static int startChamberCount;
    
    private static int _levelsComplete;
    private int _defaultChamberCount = 9;
    private float _frameTime;
    private float _prevFrameTime;
    
    protected void Init() {
        Application.targetFrameRate = targetFrameRate;
        startChamberCount = LevelSize();
    }

    /**
     * Return the current FrameTime.
     */
    public float GetFrameTime() {
        return _frameTime;
    }

    /**
     * Signal the LevelManager that a level has been completed.
     */
    public void LevelComplete() {
        _levelsComplete++;
        
        if (_levelsComplete == targetLevelComplete) {
            _levelsComplete = 0;
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /**
     * Calculate the current FrameTime
     */
    protected IEnumerator FrameTime() {
        while (SceneManager.GetActiveScene().isLoaded) {
            yield return new WaitForEndOfFrame();
            
            _frameTime = Time.time - _prevFrameTime;
            _prevFrameTime = Time.time;
        }
    }

    /**
     * Virtual Function that must be overridden per level.
     */
    protected virtual void GenerateLevel() { }

    /**
     * Generate a list of Chamber spawn locations.
     */
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

    private int LevelSize() {
        if (startChamberCount == 0) {
            startChamberCount = _defaultChamberCount;
        }

        double squRt = Math.Sqrt(startChamberCount);
        double squrProd = (squRt + 1) * (squRt + 1);

        return (int)squrProd;
    }
}
