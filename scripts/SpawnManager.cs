using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleprefab;
    private Vector3 posobstacle=new Vector3(13.59694f, 0,0);
    private float stardelay = 2;
    private float repeatrate = 2;
    private PlayerController playercontrollerscript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnobstacle", stardelay, repeatrate);
        playercontrollerscript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawnobstacle()
    {
        if (playercontrollerscript.gameover == false)
        {
            Instantiate(obstacleprefab, posobstacle, obstacleprefab.transform.rotation);

        }
    }
}
