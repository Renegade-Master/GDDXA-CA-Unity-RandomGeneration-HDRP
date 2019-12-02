using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float frameTime;

    private float _prevFrameTime;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    protected IEnumerator FrameTime() {
        while (SceneManager.GetActiveScene().isLoaded) {
            yield return new WaitForEndOfFrame();
            
            frameTime = Time.time - _prevFrameTime;
            _prevFrameTime = Time.time;
        }
    }
}
