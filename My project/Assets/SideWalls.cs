using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck")) //when puck hits the goals
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            collision.gameObject.SendMessage("RestartGame", 0f, SendMessageOptions.RequireReceiver); // restarts the game, returning puck to center and giving point
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
