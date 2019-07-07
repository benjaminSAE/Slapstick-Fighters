using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls_movement_global : MonoBehaviour
{

    //adding variables for dynamic control options
    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode dodge;
    public KeyCode attack;

    //naming variables from "stats_global" for basic movement
    float rotationSpeed;
    float movementSpeed;
    float rotation;

    //naming variables from "stats_global" for all things dodging
    float dodgeDistance;
    float dodgeSpeed;
    float dodgeCooldown;
    float nextDodge;
    float dodgeStamina;
    bool damageBlocker;

    float currentStaminaPoints;
    public Text staminaText;

    // Start is called before the first frame update
    void Start()
    {

        //initialising variables from "stats_global" for basic movement
        movementSpeed = gameObject.GetComponent<stats_global>().movementSpeed;
        rotation = gameObject.GetComponent<stats_global>().rotation;
        rotationSpeed = gameObject.GetComponent<stats_global>().rotationSpeed;

        //initialising variables from "stats_global" for dodging
        dodgeDistance = gameObject.GetComponent<stats_global>().dodgeDistance;
        dodgeSpeed = gameObject.GetComponent<stats_global>().dodgeSpeed;
        dodgeCooldown = gameObject.GetComponent<stats_global>().dodgeCooldown;
        dodgeStamina = gameObject.GetComponent<stats_global>().dodgeStamina;
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

        currentStaminaPoints = gameObject.GetComponent<stamina_global>().currentStaminaPoints;

        staminaText.text = "Current Stamina: " + currentStaminaPoints.ToString();
        print("Damage Blocker: " + currentStaminaPoints);

        //running specific methods defined below
        DodgeControls();
        MovementControls();
    }


    //translates position of object according to object's "dodgeDistance" while rotating object towards direction of movement
    //"nextDodge = Time.time + dodgeCooldown;" calculates the cooldown as specified with "dodgeCooldown" from "stats_global" in seconds
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
                        transform.Translate(0.75f * dodgeDistance, 0.0f, 0.75f * dodgeDistance, Space.World);
                        rotation = 45.0f;
                        nextDodge = Time.time + dodgeCooldown;
                        stamina_global.Instance.DodgeStamina();
                        damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
                    }

                    //top/left dodge movement
                    if (Input.GetKey(up) && Input.GetKey(left))
                    {
                        transform.Translate(-0.75f * dodgeDistance, 0.0f, 0.75f * dodgeDistance, Space.World);
                        rotation = -45.0f;
                        nextDodge = Time.time + dodgeCooldown;
                        stamina_global.Instance.DodgeStamina();
                        damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
                    }

                    //bottom/right dodge movement
                    if (Input.GetKey(down) && Input.GetKey(right))
                    {
                        transform.Translate(0.75f * dodgeDistance, 0.0f, -0.75f * dodgeDistance, Space.World);
                        rotation = 135.0f;
                        nextDodge = Time.time + dodgeCooldown;
                        stamina_global.Instance.DodgeStamina();
                        damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
                    }

                    //bottom/left dodge movement
                    if (Input.GetKey(down) && Input.GetKey(left))
                    {
                        transform.Translate(-0.75f * dodgeDistance, 0.0f, -0.75f * dodgeDistance, Space.World);
                        rotation = -135.0f;
                        nextDodge = Time.time + dodgeCooldown;
                        stamina_global.Instance.DodgeStamina();
                        damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
                    }

                    //upwards dodge movement
                    if (Input.GetKey(up))
                    {
                        if (Input.GetKey(right) || Input.GetKey(down) || Input.GetKey(left))
                        {

                        }
                        else
                        {
                            transform.Translate(0.0f, 0.0f, 1.0f * dodgeDistance, Space.World);
                            rotation = 0.1f;
                            nextDodge = Time.time + dodgeCooldown;
                            stamina_global.Instance.DodgeStamina();
                            damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
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
                            transform.Translate(1.0f * dodgeDistance, 0.0f, 0.0f, Space.World);
                            rotation = 89.9f;
                            nextDodge = Time.time + dodgeCooldown;
                            stamina_global.Instance.DodgeStamina();
                            damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
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
                            transform.Translate(0.0f, 0.0f, -1.0f * dodgeDistance, Space.World);
                            rotation = -178.9f;
                            nextDodge = Time.time + dodgeCooldown;
                            stamina_global.Instance.DodgeStamina();
                            damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
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
                            transform.Translate(-1.0f * dodgeDistance, 0.0f, 0.0f, Space.World);
                            rotation = -89.9f;
                            nextDodge = Time.time + dodgeCooldown;
                            stamina_global.Instance.DodgeStamina();
                            damageBlocker = gameObject.GetComponent<stats_global>().damageBlocker;
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
}
