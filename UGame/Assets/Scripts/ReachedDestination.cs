using UnityEngine;

public class ReachedDestination : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().LevelComplete();
        }
    }
}
