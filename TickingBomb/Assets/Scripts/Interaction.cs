using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    private bool visible;

    public GameObject rayStart;

    public GameObject connectedWires;
    public GameObject wires;
    public bool isWireConnected;
    public GameObject button;

    public PlayerCameraMovement PCMX, PCMY;

    public GameObject youWin;
    public GameObject youLost;

    public GameObject inGameHUD;

    private void Start()
    {
        isWireConnected = false;
    }
    // Update is called once per frame
    void Update()
    {
        RayCastActivator();
        ConnectingWires();

    }

    private void FixedUpdate()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Physics.Raycast(rayStart.transform.position, rayStart.transform.forward, out hit, 100))
        {
            Debug.DrawLine(rayStart.transform.position, hit.point);
        }
    }

    void RayCastActivator()
    {

        //raycast from pliers
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(rayStart.transform.position, rayStart.transform.forward, out hit, 100))
            {
                Debug.DrawLine(rayStart.transform.position, hit.point);
                print(hit.collider.name);
            }
        }
    }

    void ConnectingWires()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayStart.transform.position, rayStart.transform.forward, out hit, 100))
            {
                print(hit.collider.name);

                if (hit.collider.CompareTag("Wires"))
                {
                    isWireConnected = true;
                    connectedWires.SetActive(true);
                    wires.SetActive(false);
                }

                if (hit.collider.CompareTag("Button") && isWireConnected == true)
                {
                    Debug.Log("Wire Connected You Win");
                    youWin.SetActive(true);
                    inGameHUD.SetActive(false);
                    Time.timeScale = 0f;
                    PCMX.canMove = false;
                    PCMY.canMove = false;
                    Cursor.visible = true;
                }
                else
                {
                    Time.timeScale = 1f;
                }

                if (hit.collider.CompareTag("Button") && isWireConnected == false)
                {
                    Debug.Log("Wire Not Connected");
                }
            }

            Debug.DrawLine(ray.origin, hit.point);
        }
    }
}