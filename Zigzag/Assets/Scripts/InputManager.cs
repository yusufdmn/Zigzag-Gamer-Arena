using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    Touch touch;
    [SerializeField] ScoreManager scoreManager;  
    public UnityEvent ScreenClicked;

    void Update()
    {

        if(GameManager.Instance.currentState != GameManager.GameState.InGame){
            return;
        }
        
    #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0)){
            ScreenClicked.Invoke();
        }
        
    #else
        if(Input.touchCount > 0){          
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                ScreenClicked.Invoke();
            }
        }
    #endif
    }

}