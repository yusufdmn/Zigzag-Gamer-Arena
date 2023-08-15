using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] float minNoise, maxNoise;
    void OnEnable()
    {
        RandomizePosition(transform, transform.position);
    }

    void RandomizePosition(Transform objTransform, Vector3 origin){
        objTransform.position += new Vector3(Random.Range(minNoise, maxNoise), Random.Range(minNoise, maxNoise), 0);
    }
}
