using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    private float speed = 30f;
    private PlayerController playercontrollerscript;
    private float leftdistance=-15;
    // Start is called before the first frame update
    void Start()
    {
        playercontrollerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrollerscript.gameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftdistance && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
