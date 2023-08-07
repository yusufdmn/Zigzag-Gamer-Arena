using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    Color lerpedColor = Color.white;
    Color transparantColor = new Color(250,250,250,0);
    [SerializeField] Text tapToStart;

    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, transparantColor, Mathf.PingPong(Time.time, 1));
        tapToStart.color = lerpedColor;
    }
}