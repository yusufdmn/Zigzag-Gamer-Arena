using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Vector3 lastCheckPoint;
    public PlayerMovement.Direction lastDirection;
    [SerializeField] PlayerMovement playerMovement;


    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("checkpoint")){
            lastCheckPoint = collider.gameObject.transform.position;
            lastDirection = playerMovement.currentDirection;
        }            
        
    }
}