using UnityEngine;

public class Player : MonoBehaviour
{   
    public PolygonCollider2D playerCollider;
    public float maxSpeed;
    public float defaultSpeed;
    [Range(0, 10)] public float speed;

    void Start()
    {
        playerCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
}