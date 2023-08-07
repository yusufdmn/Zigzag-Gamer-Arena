using UnityEngine;

public class GameManager : MonoBehaviour
{
#region Singleton
    private static GameManager _instance;       // ******Definition of Singleton********
    public static GameManager Instance { get { return _instance; } }
    private void Awake() 
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }                                            // ******Definition of Singleton********
#endregion

    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject startPanel;
    private int failNumber;
    [SerializeField] int maxFailNumber;

    public enum GameState{
        Start,
        InGame,
        Failed,
        Ended
    }
    public GameState currentState;
    

    void Start()
    {
        currentState = GameState.Start;
    }

    public void StartGame(){
        startPanel.SetActive(false);
        currentState = GameState.InGame;
    }    

    public void Fail(){
        failNumber++;
        if(failNumber >= maxFailNumber){
            EndGame();
        }
        else{
            failPanel.SetActive(true);
            currentState = GameState.Failed;
        }
    }

    public  void ResumeGame(){
        failPanel.SetActive(false);
        currentState = GameState.InGame;
    }

    public void EndGame(){
        currentState = GameState.Ended;
    }


}