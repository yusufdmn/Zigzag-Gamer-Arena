using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] GameObject checkpoint;

    void Start()
    {
        if(ScoreManager.score % 10 == 0){
            checkpoint.SetActive(true);
        }
    }

}
