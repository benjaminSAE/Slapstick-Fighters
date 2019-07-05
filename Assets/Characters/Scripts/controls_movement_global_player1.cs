using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls_movement_global_player1 : MonoBehaviour
{
    int rotationSpeed = 100;
    int movementSpeed = 2;
    float rotation = 0.1f;
    public Text rotationText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rotation > 180)
        {
            rotation = -179;
        }

        if (rotation < -180)
        {
            rotation = 179;
        }

        rotationText.text = rotation.ToString();

        //left movement/rotation
        if (Input.GetKey(KeyCode.A))
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
        if (Input.GetKey(KeyCode.D))
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
        if (Input.GetKey(KeyCode.W))
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
        if (Input.GetKey(KeyCode.S))
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


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }
}
