using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Vector2 defaultDirection;
    Vector2 leftDirection;
    Vector2 downDirection;
    Vector2 currentCloudDirection;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] InputManager inputManager;
    [SerializeField] float cloudSpeed;

    [SerializeField] Material cloudMaterial;
    Vector2 offset;

    void Start()
    {
        cloudMaterial = GetComponent<Renderer>().material;

        inputManager.OnScreenClick.AddListener(SetDireciton);

        defaultDirection = Vector2.right;
        leftDirection = Vector2.right;
        downDirection = Vector2.up;

        currentCloudDirection = defaultDirection *cloudSpeed;
    }


    void Update()
    {
        offset = Time.deltaTime * currentCloudDirection;
        cloudMaterial.mainTextureOffset += offset;
    }

    private void SetDireciton(){
        if(playerMovement.currentDirection == PlayerMovement.Direction.forward)
            currentCloudDirection = leftDirection;
        else    
            currentCloudDirection = downDirection;
        
        currentCloudDirection += defaultDirection;
        currentCloudDirection *= cloudSpeed;
    }

    
}