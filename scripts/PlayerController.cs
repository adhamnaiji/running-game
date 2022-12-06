using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    public ParticleSystem explosion;
    public ParticleSystem dirtparticle;
    public AudioSource playersounds;
    public AudioClip jumpaudio;
    public AudioClip crashsound;


    public float jumpfore=45;
    public float gravityModfier=1;
    private bool isOnGround=true;
    public bool gameover=false;
    private Animator playeranim;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        playersounds = GetComponent<AudioSource>();
        Physics.gravity *=gravityModfier;
        playeranim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameover){
        player.AddForce(Vector3.up*jumpfore,ForceMode.Impulse);
        isOnGround=false;
        playeranim.SetTrigger("Jump_trig");
        dirtparticle.Stop();
            playersounds.PlayOneShot(jumpaudio, 1.0f);


        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtparticle.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            Debug.Log("game is over");
            playeranim.SetBool("Death_b", true);
            playeranim.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirtparticle.Stop();
            playersounds.PlayOneShot(crashsound, 1.0f);


        }

    }
}
