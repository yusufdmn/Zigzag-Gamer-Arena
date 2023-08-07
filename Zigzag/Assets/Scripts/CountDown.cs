using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] Text countdownText;
    float countdownValue;
    int seconds;
    void OnEnable(){
        countdownValue = 3;
    }

    void Update()
    {
        if(countdownValue > 0){
            countdownValue -= Time.deltaTime;
            seconds = Mathf.CeilToInt(countdownValue);
            countdownText.text = seconds.ToString();
        }
        else{
            GameManager.Instance.ResumeGame();
        }
    }
}