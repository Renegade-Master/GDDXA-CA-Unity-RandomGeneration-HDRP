using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightFlicker : MonoBehaviour {
    public float onTime;
    public float offTime;

    private float _timeElapsed;
    private bool _dimmer;

    private Light _light;
    private LevelManager _manager;
    
    // Start is called before the first frame update
    void Start() {
        _light = gameObject.GetComponent<Light>();
        _manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
        //Debug.Log("Time now: " + Time.time);
        _timeElapsed = 0.0f;
        StartCoroutine(LightPulse());
    }

    // Update is called once per frame
    void LateUpdate() {
        //Debug.Log("Updating Time: " + _timeElapsed);
    }

    private IEnumerator LightPulse() {
        //Debug.Log("Calling coroutine");
        
        while (SceneManager.GetActiveScene().isLoaded) {
            yield return new WaitForSeconds(0.016f);
            _timeElapsed += _manager.frameTime;
            Debug.Log("Time elapsed: " + _timeElapsed);

            // Establish dim or brighten
            // Change from dim to brighten
            if (_dimmer && (_timeElapsed > offTime)) {
                _dimmer = false;
                _timeElapsed = 0.0f;
            }

            // Change from brighten to dim
            if (!_dimmer && (_timeElapsed > onTime)) {
                _dimmer = true;
                _timeElapsed = 0.0f;
            }

            // Change Light Level
            switch (_dimmer) {
                // Getting darker
                case true:
                    Debug.Log("Getting Darker");
                    _light.range = 0.0f;
                    break;
                // Getting brighter
                case false:
                    Debug.Log("Getting Brighter");
                    _light.range = 25.0f;
                    break;
            }

            Debug.Log("Time elapsed: " + _timeElapsed);
        }
    }
}
