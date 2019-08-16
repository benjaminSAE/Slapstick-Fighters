using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_movement_controls : MonoBehaviour
{

    //adding variables for dynamic control options
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode dodge;
    [SerializeField] private Animator animator;
    GameObject CharacterSelectValues;
    int playerOne;
    int playerTwo;

    private float InputX;
    private float InputY;
    

    //naming variables from "stats_global" for basic movement
    float rotationSpeed;
    float movementSpeed;
    [HideInInspector]
    public float rotation;

    //naming variables from "stats_global" for all things dodging
    float dodgeDistance;
    float baseDodgeDistance = 0.017f;
    float baseDodgeDistanceCorner = 0.6f;
    float dodgeSpeed; //currently not doing anything
    float dodgeCooldown;
    float nextDodge;
    float dodgeStamina;
    [HideInInspector] public bool damageBlocker;
    
    float currentStaminaPoints;

    //FMOD
    //[FMODUnity.EventRef] [SerializeField] private string walkingSounds;
    //FMOD.Studio.EventInstance walkingEvent;
    [SerializeField] private float walkingSoundSpeed;
    [SerializeField] private float dodgingSoundSpeed;
    private bool isWalking = false;
    private bool isDodging = false;

    // Start is called before the first frame update
    void Start()
    {
        //setting speed of walking sounds
        InvokeRepeating("CallFootsteps", 0, walkingSoundSpeed);
        InvokeRepeating("CallDodging", 0, dodgingSoundSpeed);
        animator = this.gameObject.GetComponent<Animator>();
        //walkingEvent.start();

        //initialising variables from "stats_global" for basic movement
        movementSpeed = gameObject.GetComponent<global_stats>().movementSpeed;
        rotation = gameObject.GetComponent<global_stats>().rotation;
        rotationSpeed = gameObject.GetComponent<global_stats>().rotationSpeed;

        //initialising variables from "stats_global" for dodging
        dodgeDistance = gameObject.GetComponent<global_stats>().dodgeDistance;
        dodgeSpeed = gameObject.GetComponent<global_stats>().dodgeSpeed;
        dodgeCooldown = gameObject.GetComponent<global_stats>().dodgeCooldown;
        dodgeStamina = gameObject.GetComponent<global_stats>().dodgeStamina;
        damageBlocker = false;
        CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        playerOne = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer1;
        playerTwo = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer2;
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        animator.SetFloat("InputX", InputX);
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);

        //correcting rotation values to equal tangable rotation limits
        if (rotation > 180)
        {
            rotation = -179;
        }

        if (rotation < -180)
        {
            rotation = 179;
        }

        currentStaminaPoints = gameObject.GetComponent<global_stamina>().currentStaminaPoints;

        //running specific methods defined below
        DodgeControls();
        MovementControls();
    }

    //an emergency function to stop the character from rotating if needed.
    public void StopRotation()
    {
        //upwards rotation lock
        if (rotation > -3 && rotation < 3)
        {
            rotation = 0f;
        }

        //upwards/right rotation lock
        if (rotation > 42 && rotation < 48)
        {
            rotation = 45f;
        }

        //right rotation lock
        if (rotation > 87 && rotation < 93)
        {
            rotation = 90f;
        }

        //downwards/right rotation lock
        if (rotation > 132 && rotation < 138)
        {
            rotation = 135f;
        }

        //downwards rotation lock
        if (rotation > 177 && rotation < 183 || rotation > -183 && rotation < -177)
        {
            rotation = 179f;
        }

        //downwards/left rotation lock
        if (rotation > -138 && rotation < -132)
        {
            rotation = -135f;
        }

        //left rotation lock
        if (rotation > -93 && rotation < -87)
        {
            rotation = -90f;
        }

        //upwards/left rotation lock
        if (rotation > -48 && rotation < -42)
        {
            rotation = -45f;
        }
    }

    //translates position of object according to object's "dodgeDistance" while rotating object towards direction of movement
    //"nextDodge = Time.time + dodgeCooldown;" calculates the cooldown as specified with "dodgeCooldown" from "stats_global" in seconds
    //stamina_global stamina_globalInstance = GetComponent<stamina_global>(); + stamina_globalInstance.DodgeStamina(); runs the stamina script on this character.
    void DodgeControls()
    {
        if (currentStaminaPoints > dodgeStamina)
        {
            if (Time.time > nextDodge)
            {
                if (Input.GetKey(dodge))
                {

                   //if player class !=tank
                   
                    animator.SetBool("isDodging", true);
                    //setting the cooldown before the next dodge can be activated
                    nextDodge = Time.time + dodgeCooldown;

                    //runs the method from "global_stamina" to use an amount of stamina points
                    global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                    stamina_globalInstance.DodgeStamina();

                    //changing whether or not this character blocks damage when using their "dodge" ability
                    damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                    }
                else
                {
                    animator.SetBool("isDodging", false);
                     // help Vector3 left || Vector3 right = new Vector3(-baseDodgeDistance * dodgeDistance, 0, 0);
                    damageBlocker = false;
                }
            }
            else
            {
                damageBlocker = false;
            }
        }
        else
        {
            damageBlocker = false;
        }
    }

    //translates position of object steadily, according to "movementSpeed", while steadily rotating object towards direction of movement
    void MovementControls()
    {
        //left movement/rotation
        if (Input.GetKey(left))
        {
         
            if (rotation > -90
             && rotation < 0)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > 0
             && rotation < 90)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < -90
             && rotation > -180)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 180
             && rotation > 90)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //right movement/rotation
        if (Input.GetKey(right))
        {
           
            if (rotation < 90
             && rotation > 0)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 0
             && rotation > -90)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > 90
             && rotation < 180)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > -180
             && rotation < -90)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //forward movement/rotation
        if (Input.GetKey(up))
        {
            
            if (rotation > 0)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 0)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //backwards movement/rotation    
        if (Input.GetKey(down))
        {
            
            if (rotation > -180
             && rotation < 0)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 180
             && rotation > 0)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //top/right movement/rotation
        if (Input.GetKey(up) && Input.GetKey(right))
        {
            
            if (rotation < 45
             && rotation > -135)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > 45
             && rotation < 180)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > -180
             && rotation < -135)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //top/left movement/rotation
        if (Input.GetKey(up) && Input.GetKey(left))
        {
           
            if (rotation > -45
             && rotation < 135)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < -45
             && rotation > -180)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 180
             && rotation > 135)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
           
        }

        //bottom/right movement/rotation
        if (Input.GetKey(down) && Input.GetKey(right))
        {
            
            if (rotation < 135
             && rotation > -45)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < -45
             && rotation > -180)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation > 135
             && rotation < 180)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            
        }

        //bottom/left movement/rotation
        if (Input.GetKey(down) && Input.GetKey(left))
        {
          
            if (rotation > -135
             && rotation < 45)
            {
                rotation -= Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < -135
             && rotation > -180)
            {
                rotation += Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }

            if (rotation < 180
             && rotation > 45)
            {
                rotation += Time.deltaTime * rotationSpeed;

                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
           
        }

        //translates position of object
        if (Input.GetKey(up) || Input.GetKey(left) || Input.GetKey(down) || Input.GetKey(right))
        {          
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            animator.SetBool("isMoving", true);
            isWalking = true;
            print("isWalking = " + isWalking);
        }
        else
        {
            animator.SetBool("isMoving", false);
            isWalking = false;
            print("isWalking = " + isWalking);
        }
    }

    void CallFootsteps()
    {
        if (isWalking == true)
        {
            BG_CharacterAudio characterAudioInstance = GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.Walking);
        }
    }

    void CallDodging()
    {
        if(isDodging == true)
        {
            BG_CharacterAudio characterAudioInstance = GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.Dodging);
        }
    }

    //this is the Coroutine
    //IEnumerator smooth_move(Vector3 direction, float speed)
    //{
    //    float startime = Time.time;
    //    Vector3 start_pos = transform.position; //Starting position.
    //    Vector3 end_pos = transform.position + direction; //Ending position.

    //    while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
    //    {
    //        float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

    //        isDodging = true;

    //        transform.position += direction * move;

    //        yield return null;
    //    }

    //    isDodging = false;
    //}
}
