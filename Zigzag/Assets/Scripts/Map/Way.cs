using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] GameObject diamond;
    void OnEnable()
    {        
        if(Random.Range(0,7) == 1)
            diamond.SetActive(true);
        else    
            diamond.SetActive(false);
    }

}