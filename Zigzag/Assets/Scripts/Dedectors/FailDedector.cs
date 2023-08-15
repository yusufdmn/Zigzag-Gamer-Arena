using UnityEngine;

public class FailDedector : MonoBehaviour
{
   [SerializeField] CheckpointDedector checkpointDedector;
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
      Vector2 birthPosition = checkpointDedector.lastCheckpoint;
      PlayerMovement.Direction birthDirection = checkpointDedector.lastDirection;

      transform.position = birthPosition;
      playerMovement.SetDirection(birthDirection);
   }
}