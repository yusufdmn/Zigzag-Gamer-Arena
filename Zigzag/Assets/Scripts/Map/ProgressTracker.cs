using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public int passedWayAmount;
    public bool WayGenerationStarted;
    [SerializeField] MapGenerator mapGenerator;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("way")){
            passedWayAmount++;
            
            if(passedWayAmount > 15){
                WayGenerationStarted = true;
                mapGenerator.GenerateWay();
            }
        }
    }

}