using UnityEngine;

public class Player : MonoBehaviour
{   
    public PolygonCollider2D playerCollider;
    [Range(0, 10)] public float speed;
    public float maxSpeed;
    public float defaultSpeed;

    void Start()
    {
        playerCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
}