using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int startingLevels;
    public float placementOffset;
    
    private float _frameTime;
    private float _prevFrameTime;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public float GetFrameTime() {
        return _frameTime;
    }

    protected IEnumerator FrameTime() {
        while (SceneManager.GetActiveScene().isLoaded) {
            yield return new WaitForEndOfFrame();
            
            _frameTime = Time.time - _prevFrameTime;
            _prevFrameTime = Time.time;
        }
    }

    protected virtual void GenerateLevel() {
        Debug.Log("Congratulations, from Level Manager Superclass");
    }

    protected List<Vector3> GenerateRoomLocations(int chamberCount) {
        List<Vector3> locations = new List<Vector3>();
        
        double rowsCols = Math.Sqrt(chamberCount);
        
        // Is the Chamber count valid?
        if((chamberCount % rowsCols) != 0) {
            Debug.Log("Level generation failed.  Please enter a Square Integer for Chamber count.");
        } else {
            //Debug.Log("Something went well.  There are " + rowsCols + " Columns and Rows.");

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
