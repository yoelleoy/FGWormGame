using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float jump = 5f;
    public float speed = 10f;
    float horizontalSpeed = 2.0f;
    public bool isGrounded = false;
    public int HP = 10;
    public GameObject floatingCam;
    public GameObject currentCam;
    public float height = 20f;
    public static bool reset = true;
    public Rigidbody shot;
    public float shotSpeed = 5f;
    public GameObject shotSpawn;
    private bool dead = false;
    public GameObject Tag;
    public GameObject DeadUI;
    public bool hasShot = false;
    public bool canMove = true;
    public float currentTime = 15f;
    public static bool changePlayer = false;
    public float gracePeriod = 5f;
    public TMP_Text TimerUI;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Trigger check for explosion damage, deal damage and if dead, set tag to dead and show death UI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageCol") && (!dead))
        {
            HP = HP - 1;
        }

        if (HP <= 0)
        {
            Tag.tag="Dead";
            DeadUI.SetActive(true);
            dead = true;         
        }
    }
    void OnCollisionEnter(Collision other)
    {   //Jump check
        if (other.gameObject.CompareTag("Terrain") && (!isGrounded))
        {
            isGrounded = true;
        }
        //Falling into the void check
        if (other.gameObject.CompareTag("Death"))
        {
            HP = 0;
        }

        if (HP <= 0)
        {   //Another death check for when players fall into the void
            Tag.tag = "Dead";
            DeadUI.SetActive(true);
            dead = true;
        }
    }

    void Update()
    {   //If current player is dead, change to another players turn
        if (dead == true)
        {
            changePlayer = true;
        }
        //Individual player timer, with a small pause when time runs out before it switchs to the next player
        if (!Input.GetKey(KeyCode.F))
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                TimerUI.text = (Mathf.RoundToInt(currentTime)) + " seconds left".ToString();
            }
            else
            {
                gracePeriod -= Time.deltaTime;
                canMove = false;

                if (gracePeriod < 0)
                {
                    changePlayer = true;
                }
            }
        }
        //If the player is alive, has not shot yet and their turn hasnt run out, they can press left click to shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && (!dead) && (!hasShot) &&(canMove))
        {
            Rigidbody p = Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            p.velocity = shotSpawn.transform.forward * shotSpeed;
            hasShot = true;
        }      
        //If F is held down, swap camera to the map camera
        if (Input.GetKey(KeyCode.F) && (reset == true) && (!dead) && (canMove))
        {
            currentCam.SetActive(false);
            floatingCam.SetActive(true);
        }
        else
        {
            currentCam.SetActive(true);
            floatingCam.SetActive(false);
        }
       //This reset check is to make sure that if a player is holding down F when it swaps to another player, that it does not stay on the map camera
       if(Input.GetKeyDown(KeyCode.F)|| Input.GetKeyUp(KeyCode.F))
        {
            reset = true;           
        }
        //Controls the player movement, resets map camera position to default when not using it
        if (!Input.GetKey(KeyCode.F) && (!dead) && (canMove))
        {   //Player looking around with mouse
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, h, 0);
            floatingCam.transform.position = new Vector3(0, height, 0);
            //Player jump if grounded
            if ((Input.GetKeyDown(KeyCode.Space))&&(isGrounded==true) && (!dead) && (canMove))
             {
            rb.AddForce(transform.up * jump, ForceMode.VelocityChange);
            isGrounded = false;
             }
            //Player movement
            if ((!dead) && (canMove))
             {
                float xMove = Input.GetAxisRaw("Horizontal");
                float zMove = Input.GetAxisRaw("Vertical");
                var worldVelocity = new Vector3(xMove * speed, rb.velocity.y, zMove * speed);
                rb.velocity = transform.TransformDirection(worldVelocity);
             }
        }
    }

  




}
