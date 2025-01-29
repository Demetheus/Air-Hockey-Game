using UnityEngine;

public class Puck : MonoBehaviour
{
    public float minX = -4f;
    public float maxX = 4f; // Adjust this to split the field between players
    public float minY = -6f;
    public float maxY = 6f;
    public float maxSpeed = 8f;
    private Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void GoPuck()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(10, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-10, -15));
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoPuck", 1);
    }
    void ResetPuck()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetPuck();
        Invoke("GoPuck", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.linearVelocity.magnitude > maxSpeed)
        {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxSpeed;
        }


    }

}
