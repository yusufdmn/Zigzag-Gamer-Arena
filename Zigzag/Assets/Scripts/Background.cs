using UnityEngine;

public class Background : MonoBehaviour
{

    Material mat;
    Vector2 offset;

    public Vector2 speed;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        offset = Time.deltaTime * speed;
        mat.mainTextureOffset += offset;       
    }
}