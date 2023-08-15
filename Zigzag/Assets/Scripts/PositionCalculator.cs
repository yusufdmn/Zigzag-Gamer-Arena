using UnityEngine;

public class PositionCalculator
{

    // Position Calculations based on the previous and next ways' type.

    public static Vector2 Calculate_Horizontal_Vertical_Pos(GameObject nextWay, Transform previousWay){
        float x = previousWay.position.x + (previousWay.localScale.x - nextWay.transform.localScale.x) / 2; 
        float y = previousWay.position.y + (previousWay.localScale.y + nextWay.transform.localScale.y) / 2 ;
        Vector2 position = new Vector2(x,y);
        return position;
    }

    public static Vector2 Calculate_Horizontal_Horizontal_Pos(GameObject nextWay, Transform previousWay){
        float x = previousWay.position.x + (previousWay.transform.localScale.x + nextWay.transform.localScale.x) / 2;
        float y = previousWay.position.y;
        Vector2 position = new Vector2(x,y);
        return position;
    }

    public static Vector2 Calculate_Vertical_Horizontal_Pos(GameObject nextWay, Transform previousWay){
        float x = previousWay.position.x + (previousWay.transform.localScale.x + nextWay.transform.localScale.x) / 2;
        float y = previousWay.position.y + (previousWay.transform.localScale.y - nextWay.transform.localScale.y) / 2;
        Vector2 position = new Vector2(x,y);
        return position;
    }

    public static Vector2 Calculate_Vertical_Vertical_Pos(GameObject nextWay, Transform previousWay){
        float x = previousWay.position.x;
        float y = previousWay.position.y + (previousWay.localScale.y + nextWay.transform.localScale.y) / 2;
        Vector2 position = new Vector2(x,y);
        return position;
    }



}
