using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public enum Direction{
    right,
    forward
};

#region Variables

    public Direction currentDirection; // 1 = forward, 0 = right

    [SerializeField] InputManager inputManager;
    [SerializeField] Player player;

    private Transform playerTransform;
    private Vector2 moveDirection;
    private Vector2 forwardDirection = new Vector2(0,1);
    private Vector2 rightDirection = new Vector2(1,0);

#endregion

    void Start()
    {
        inputManager.ScreenClicked.AddListener(ChangeDirection);
        forwardDirection.Normalize();
        rightDirection.Normalize();

        moveDirection = forwardDirection;
        playerTransform = transform;
        currentDirection = Direction.forward;
    }

    void Update()
    {
        if(GameManager.Instance.currentState != GameManager.GameState.InGame){
            return;
        }
        
        MovePlayer();
    }

#region Functions

    void TurnPlayerRight(){
        moveDirection = rightDirection;
        currentDirection = Direction.right;
    }

    void TurnPlayerForward(){
        moveDirection = forwardDirection;
        currentDirection = Direction.forward;
    }

    private void ChangeDirection(){     // Change direction after click
        if(currentDirection == Direction.forward){
            TurnPlayerRight();
        }
        else{
            TurnPlayerForward();
        }
        RotatePlayer();
    }

    public void SetDirection(Direction direction){      // Set direction after fail.
        if(direction == Direction.forward){
            TurnPlayerForward();
            }
        else{
            TurnPlayerRight();
        }
        RotatePlayer();
    }    


    private void MovePlayer(){
        playerTransform.Translate(moveDirection * player.speed * Time.deltaTime, Space.World);
    }

    private void RotatePlayer(){
        float z = -90 + ((int)currentDirection * 90);
        
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, z));
        playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, 90);
    }
#endregion
    
}