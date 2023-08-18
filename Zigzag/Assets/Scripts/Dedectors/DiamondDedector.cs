using UnityEngine;

public class DiamondDedector : MonoBehaviour
{
    [SerializeField] int diamondValue; 
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] AudioSource collectSound;
    [SerializeField] DiamondController diamondController;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("diamond")){
            scoreManager.IncreaseScore(diamondValue);
            diamondController.RepositionTheText(collider.transform.position); // Display the extra point text/animation
            collectSound.Play();
            collider.gameObject.SetActive(false);
        }
    }
}
