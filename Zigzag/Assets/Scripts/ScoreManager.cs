using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    [SerializeField] Text scoreText;
    [SerializeField] InputManager inputManager;

    void Start(){
        inputManager.ScreenClicked.AddListener(IncreaseScoreOne);
    }

    public void IncreaseScoreOne(){
        score++;
        scoreText.text = score.ToString();
    }
    
}
