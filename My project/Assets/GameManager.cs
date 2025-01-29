using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public GUISkin layout;
    GameObject thePuck;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePuck = GameObject.FindWithTag("Ball");
    }
    public static void Score (string goalID)
    {
        if (goalID == "RightGoal")
        {
            PlayerScore1++;
        }
        if (goalID == "LeftGoal")
        {
            PlayerScore2++;
        }
    }
    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            thePuck.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
}
