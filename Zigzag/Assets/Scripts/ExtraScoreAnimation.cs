using System.Collections;
using UnityEngine;

public class ExtraScoreAnimation : MonoBehaviour
{
    float lerpValue;
    float firstLerpValue = 1;
    Vector2 target;

    void OnEnable()
    {
        target = new Vector2(transform.position.x, transform.position.y + 1);
        lerpValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lerpValue += Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, target, lerpValue);

        if(lerpValue > firstLerpValue - 0.4f){
            gameObject.SetActive(false);
        }    
    }

    

}