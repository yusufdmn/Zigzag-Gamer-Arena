using UnityEngine;
using UnityEngine.UIElements;

public class ConstantRotation : MonoBehaviour
{
    [Range(-250, 250)]
    public float rotateSpeed;
    public float minSpeed;
    public float maxSpeed;
    public bool isLocal;
    public bool isRandomized;
    
    [Header("Rotation")]
    public bool x;
    public bool y;
    public bool z;

    void Update(){
        if(x)
            RotateX();
        if(y)
            RotateY();

        if(z)
            RotateZ();
    }

    private void Start()
    {
        if (isRandomized)
            rotateSpeed = Random.Range(minSpeed, maxSpeed);
    }

    public void RotateX()
    { 
        if(isLocal)
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.World);

    }

    public void RotateY()
    {
        if (isLocal)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
    public void RotateZ()
    {
        if (isLocal)
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.World);
    }

}