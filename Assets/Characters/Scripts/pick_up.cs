using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pick_up : MonoBehaviour
{
    //note to me: you need text variables to add the stamina and health to. Two seperate ones.
    // we can also try slider for this. 
    //Ben has a stamina script already, need to reference this when adding point through pick up objects.
    //Cross-reference health as well in ben's scripts.

    // speed for the movement
    public float speed = 1.0f;

    // The Points??
    private int staminaPoints = 0;
    private int healthPoints = 0;

    // Feedback/ Text counters
    public Text staminaCount;
    public Text healthCount;



    void Update()
    {
        //just really basic movement for testing
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(h, 0, v);
    }


    void OnTriggerEnter(Collider other)
    {
        // Stamina Pick up
        if (other.gameObject.CompareTag("Stamina"))
        {
            other.gameObject.SetActive(false); // gets rid of stamina ball
            ++staminaPoints; //adds to stamina points (by one)
            staminaCount.text = staminaPoints.ToString(); // displays feedback
        }

        // Health Pick up
        if (other.gameObject.CompareTag("Health"))
        {
            other.gameObject.SetActive(false); //gets rid of health ball (do not use destroy game object, better practice to use set active)
            ++healthPoints; // adds one to the int variable for health points
            healthCount.text = healthPoints.ToString(); //displays feedback
        }
    }

    
}

