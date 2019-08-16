using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_CameraFollow : MonoBehaviour
{
    private Transform player1;
    private Transform player2;

    private Camera cam;
    private Vector3 velocity;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float minZoom = 250f;
    [SerializeField] private float maxZoom = 50f;
    [SerializeField] private float zoomLimiter = 125f;
    [SerializeField] private float smoothTime = .5f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        GameObject CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        int whichPlayer1 = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer1;
        int whichPlayer2 = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer2;

        if (whichPlayer2 == 1)
        {
            player2 = GameObject.Find("ArcherPlayer2(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer2 == 2)
        {
            player2 = GameObject.Find("KnightPlayer2(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer2 == 3)
        {
            player2 = GameObject.Find("TankPlayer2(Clone)").GetComponent<Transform>();
        }

        if (whichPlayer1 == 1)
        {
            player1 = GameObject.Find("ArcherPlayer1(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer1 == 2)
        {
            player1 = GameObject.Find("KnightPlayer1(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer1 == 3)
        {
            player1 = GameObject.Find("TankPlayer1(Clone)").GetComponent<Transform>();
        }
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(player1.position, Vector3.zero);

        bounds.Encapsulate(player1.position);
        bounds.Encapsulate(player2.position);

        return (bounds.size.x + bounds.size.y) / 2;
    }

    private Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(player1.position, Vector3.zero);

        bounds.Encapsulate(player1.position);
        bounds.Encapsulate(player2.position);

        return bounds.center;
    }
}
