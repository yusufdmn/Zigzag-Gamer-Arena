using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] GameObject extraScore;

    public void RepositionTheText(Vector3 spawnPosition){
        extraScore.SetActive(false);
        extraScore.transform.position = spawnPosition;
        extraScore.SetActive(true);
    }
}
