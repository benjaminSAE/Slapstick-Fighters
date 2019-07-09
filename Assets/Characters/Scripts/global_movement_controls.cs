using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_movement_controls : MonoBehaviour
{

    //adding variables for dynamic control options
    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode dodge;

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
    bool damageBlocker;
    
    float currentStaminaPoints;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    // Update is called once per frame
    void Update()
    {
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
                    //top/right dodge movement
                    if (Input.GetKey(up) && Input.GetKey(right))
                    {
                        //setting the direction of the Coroutine and starting the Coroutine
                        Vector3 topRight = new Vector3(baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner, 0, baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner);
                        StartCoroutine(smooth_move(topRight, 1f));

                        //changing the rotation of the player equal to direction of movement
                        rotation = 45.0f;

                        //setting the cooldown before the next dodge can be activated
                        nextDodge = Time.time + dodgeCooldown;

                        //runs the method from "global_stamina" to use an amount of stamina points
                        global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                        stamina_globalInstance.DodgeStamina();

                        //changing whether or not this character blocks damage when using their "dodge" ability
                        damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                    }

                    //top/left dodge movement
                    if (Input.GetKey(up) && Input.GetKey(left))
                    {
                        //setting the direction of the Coroutine and starting the Coroutine
                        Vector3 topLeft = new Vector3(-baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner, 0, baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner);
                        StartCoroutine(smooth_move(topLeft, 1f));

                        //changing the rotation of the player equal to direction of movement
                        rotation = -45.0f;

                        //setting the cooldown before the next dodge can be activated
                        nextDodge = Time.time + dodgeCooldown;

                        //runs the method from "global_stamina" to use an amount of stamina points
                        global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                        stamina_globalInstance.DodgeStamina();

                        //changing whether or not this character blocks damage when using their "dodge" ability
                        damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                    }

                    //bottom/right dodge movement
                    if (Input.GetKey(down) && Input.GetKey(right))
                    {
                        //setting the direction of the Coroutine and starting the Coroutine
                        Vector3 bottomRight = new Vector3(baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner, 0, -baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner);
                        StartCoroutine(smooth_move(bottomRight, 1f));

                        //changing the rotation of the player equal to direction of movement
                        rotation = 135.0f;

                        //setting the cooldown before the next dodge can be activated
                        nextDodge = Time.time + dodgeCooldown;

                        //runs the method from "global_stamina" to use an amount of stamina points
                        global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                        stamina_globalInstance.DodgeStamina();

                        //changing whether or not this character blocks damage when using their "dodge" ability
                        damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                    }

                    //bottom/left dodge movement
                    if (Input.GetKey(down) && Input.GetKey(left))
                    {
                        //setting the direction of the Coroutine and starting the Coroutine
                        Vector3 bottomLeft = new Vector3(-baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner, 0, -baseDodgeDistance * dodgeDistance * baseDodgeDistanceCorner);
                        StartCoroutine(smooth_move(bottomLeft, 1f));

                        //changing the rotation of the player equal to direction of movement
                        rotation = -135.0f;

                        //setting the cooldown before the next dodge can be activated
                        nextDodge = Time.time + dodgeCooldown;

                        //runs the method from "global_stamina" to use an amount of stamina points
                        global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                        stamina_globalInstance.DodgeStamina();

                        //changing whether or not this character blocks damage when using their "dodge" ability
                        damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                    }

                    //upwards dodge movement
                    if (Input.GetKey(up))
                    {
                        if (Input.GetKey(right) || Input.GetKey(down) || Input.GetKey(left))
                        {

                        }
                        else
                        {
                            //setting the direction of the Coroutine and starting the Coroutine
                            Vector3 top = new Vector3(0, 0, baseDodgeDistance * dodgeDistance);
                            StartCoroutine(smooth_move(top, 1f));

                            //changing the rotation of the player equal to direction of movement
                            rotation = 0.1f;

                            //setting the cooldown before the next dodge can be activated
                            nextDodge = Time.time + dodgeCooldown;

                            //runs the method from "global_stamina" to use an amount of stamina points
                            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                            stamina_globalInstance.DodgeStamina();

                            //changing whether or not this character blocks damage when using their "dodge" ability
                            damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                        }
                    }

                    //right dodge movement
                    if (Input.GetKey(right))
                    {
                        if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left))
                        {

                        }
                        else
                        {
                            //setting the direction of the Coroutine and starting the Coroutine
                            Vector3 right = new Vector3(baseDodgeDistance * dodgeDistance, 0, 0);
                            StartCoroutine(smooth_move(right, 1f));

                            //changing the rotation of the player equal to direction of movement
                            rotation = 89.9f;

                            //setting the cooldown before the next dodge can be activated
                            nextDodge = Time.time + dodgeCooldown;

                            //runs the method from "global_stamina" to use an amount of stamina points
                            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                            stamina_globalInstance.DodgeStamina();

                            //changing whether or not this character blocks damage when using their "dodge" ability
                            damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                        }
                    }

                    //downwards dodge movement
                    if (Input.GetKey(down))
                    {
                        if (Input.GetKey(up) || Input.GetKey(right) || Input.GetKey(left))
                        {

                        }
                        else
                        {
                            //setting the direction of the Coroutine and starting the Coroutine
                            Vector3 bottom = new Vector3(0, 0, -baseDodgeDistance * dodgeDistance);
                            StartCoroutine(smooth_move(bottom, 1f));

                            //changing the rotation of the player equal to direction of movement
                            rotation = -178.9f;

                            //setting the cooldown before the next dodge can be activated
                            nextDodge = Time.time + dodgeCooldown;

                            //runs the method from "global_stamina" to use an amount of stamina points
                            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                            stamina_globalInstance.DodgeStamina();

                            //changing whether or not this character blocks damage when using their "dodge" ability
                            damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                        }
                    }

                    //left dodge movement
                    if (Input.GetKey(left))
                    {
                        if (Input.GetKey(up) || Input.GetKey(right) || Input.GetKey(down))
                        {

                        }
                        else
                        {
                            //setting the direction of the Coroutine and starting the Coroutine
                            Vector3 left = new Vector3(-baseDodgeDistance * dodgeDistance, 0, 0);
                            StartCoroutine(smooth_move(left, 1f));

                            //changing the rotation of the player equal to direction of movement
                            rotation = -89.9f;

                            //setting the cooldown before the next dodge can be activated
                            nextDodge = Time.time + dodgeCooldown;

                            //runs the method from "global_stamina" to use an amount of stamina points
                            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                            stamina_globalInstance.DodgeStamina();

                            //changing whether or not this character blocks damage when using their "dodge" ability
                            damageBlocker = gameObject.GetComponent<global_stats>().damageBlocker;
                        }
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
        }
    }

    IEnumerator smooth_move(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position + direction; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

            transform.position += direction * move;

            yield return null;
        }
    }
}
