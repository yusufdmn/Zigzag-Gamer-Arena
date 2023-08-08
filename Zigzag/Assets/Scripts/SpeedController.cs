using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Player player;
    [SerializeField] float extraSpeed;

    void Start()
    {      
        inputManager.ScreenClicked.AddListener(IncreaseSpeed);
    }

    public void IncreaseSpeed(){
        if(player.speed < player.maxSpeed){
            player.speed += extraSpeed;
        }
    }

    public void ResetSpeed(){
        player.speed = player.defaultSpeed;
    }

}
