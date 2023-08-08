using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Vector3 lastCheckpoint;
    public PlayerMovement.Direction lastDirection;
    [SerializeField] PlayerMovement playerMovement;

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("checkpoint")){
            lastCheckpoint = collider.gameObject.transform.position;
            lastDirection = collider.GetComponent<Checkpoint>().checkpointDirection;
        }                  
    }
}