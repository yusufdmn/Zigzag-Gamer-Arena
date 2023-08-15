using System;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Player player;
    [SerializeField] float extraSpeed;

    void Start()
    {      
        inputManager.OnScreenClick.AddListener(IncreaseSpeed);
    }

    public void IncreaseSpeed(){
        if(player.speed < player.maxSpeed){
            player.speed += extraSpeed;
        }
    }

    public void DecreaseSpeed(){
        float lowSpeed = Math.Max(player.defaultSpeed, player.speed - 1);
        player.speed = lowSpeed;
    }

}
