using UnityEngine;

public class FailDedector : MonoBehaviour
{
   [SerializeField] CheckpointController checkpointController;
   [SerializeField] PlayerMovement playerMovement;
   [SerializeField] PolygonCollider2D playerCollider;

   void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Wall")){
         playerCollider.enabled = false;
         GameManager.Instance.Fail();
         
         SetNewBirth();
      }
   }

   void SetNewBirth(){
      Vector2 birthPosition = checkpointController.lastCheckpoint;
      PlayerMovement.Direction birthDirection = checkpointController.lastDirection;

      transform.position = birthPosition;
      playerMovement.SetDirection(birthDirection);
   }
}