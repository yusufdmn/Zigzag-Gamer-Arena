using UnityEngine;

public class FailDedector : MonoBehaviour
{
   bool isInsidePath;
   [SerializeField] CheckpointController checkpointController;
   [SerializeField] PlayerMovement playerMovement;


   void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Wall")){
         Debug.Log("Failed");
         GameManager.Instance.Fail();
         
         SetNewBirth();
      }
   }


   void SetNewBirth(){
      Vector2 birthPosition = checkpointController.lastCheckPoint;
      PlayerMovement.Direction birthDirection = checkpointController.lastDirection;

      transform.position = birthPosition;
      playerMovement.SetDirection(birthDirection);
   }

}