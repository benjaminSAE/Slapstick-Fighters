using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_archer_emmiter : MonoBehaviour
{
    private float rotation;

    private float attackDistance;
    float attackDistanceBase = 0.017f;
    float attackDistanceBaseCorner = 0.6f;

    [SerializeField] private int whichPlayer;

    private void Awake()
    {
        MoveArrow();
    }

    private void MoveArrow()
    {
        if (whichPlayer == 1)
        {
            GameObject archerPlayer1 = GameObject.Find("ArcherPlayer1(Clone)");
            rotation = archerPlayer1.GetComponent<global_movement_controls>().rotation;
            attackDistance = archerPlayer1.GetComponent<global_stats>().attackDistance;
        }
        else
        {
            GameObject archerPlayer2 = GameObject.Find("ArcherPlayer2(Clone)");
            rotation = archerPlayer2.GetComponent<global_movement_controls>().rotation;
            attackDistance = archerPlayer2.GetComponent<global_stats>().attackDistance;
        }

        //upwards attack movement
        if (rotation > -22 && rotation < 22)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 top = new Vector3(0, 0, attackDistance * attackDistanceBase);
            StartCoroutine(smooth_move(top, 1f));
        }

        //upwards/right attack movement
        if (rotation > 23 && rotation < 67)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 topRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
            StartCoroutine(smooth_move(topRight, 1f));
        }

        //right attack movement
        if (rotation > 68 && rotation < 112)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 right = new Vector3(attackDistance * attackDistanceBase, 0, 0);
            StartCoroutine(smooth_move(right, 1f));
        }

        //downwards/right attack movement
        if (rotation > 113 && rotation < 157)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 bottomRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
            StartCoroutine(smooth_move(bottomRight, 1f));
        }

        //downwards attack movement
        if (rotation > 158 && rotation < 200 || rotation > -200 && rotation < -158)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 bottom = new Vector3(0, 0, -attackDistance * attackDistanceBase);
            StartCoroutine(smooth_move(bottom, 1f));
        }

        //downwards/left attack movement
        if (rotation > -157 && rotation < -113)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 bottomLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
            StartCoroutine(smooth_move(bottomLeft, 1f));
        }

        //left attack movement
        if (rotation > -112 && rotation < -68)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 left = new Vector3(-attackDistance * attackDistanceBase, 0, 0);
            StartCoroutine(smooth_move(left, 1f));
        }

        //upwards/left attack movement
        if (rotation > -67 && rotation < -23)
        {
            //setting the direction of the Coroutine and starting the Coroutine
            Vector3 topLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
            StartCoroutine(smooth_move(topLeft, 1f));
        }
    }

    //method that runs the Coroutine
    IEnumerator smooth_move(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position + direction; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

            gameObject.transform.position += direction * move;

            yield return null;
        }
    }
}
