using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField][Range(0.0001f, 5.0f)] private float backgroundRate;
    [SerializeField][Range(0.0001f, 5.0f)] private float foregroundRate;
    public GameObject[] diamonds, mountains; 
    public GameObject player;
    public Rigidbody2D playerRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        diamonds = GameObject.FindGameObjectsWithTag("BackgroundDiamonds");
        mountains = GameObject.FindGameObjectsWithTag("Mountains");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerRb.velocity.x != 0) 
        {
            for (int i = 0; i < diamonds.Length; i++) 
            {
                Transform t = diamonds[i].GetComponent<Transform>();
                t.position = new Vector3(t.position.x + playerRb.velocity.x * backgroundRate, t.position.y, t.position.z);
            }
            for (int i = 0; i < mountains.Length; i++) 
            {
                Transform t = mountains[i].GetComponent<Transform>();
                t.position = new Vector3(t.position.x + playerRb.velocity.x * foregroundRate, t.position.y, t.position.z);
            }
        }
    }
}
