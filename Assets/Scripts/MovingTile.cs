using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public float moveSpeed = 5f;
    bool goingDown = true;
    bool goingUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {
            transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

            if (transform.position.y <= -2.4)
            {
                goingDown = false;
                goingUp = true;
            }
        }
        
        if (goingUp)
        {
            transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;

            if (transform.position.y >= 7)
            {
                goingDown = true;
                goingUp = false;
            }
        }
    }
}
