using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    [SerializeField] Text scoreText;
    [SerializeField] InputManager inputManager;

    void Start(){
        inputManager.OnScreenClick.AddListener(IncreaseScoreOne);
    }

    public void IncreaseScoreOne(){
        score++;
        UpdateScoreText();
    }

    public void IncreaseScore(int extraScore){
        score += extraScore;
        UpdateScoreText();    
    }

    private void UpdateScoreText(){
        scoreText.text = score.ToString();
    }
    
}
