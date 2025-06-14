using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    //  private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRB;
    public GameObject missilePrefab;        // Asigna el prefab en el inspector
    public Transform launchPoint;           // Un GameObject vac�o en la posici�n de disparo
    public float launchForce = 20f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(transform.forward * Time.deltaTime * speed * verticalInput, Space.World);
        //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput, Space.World);
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Mantenerlo horizontal
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.5f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion localOffset = Quaternion.Euler(0, 90, -90);
            Quaternion finalRotation = launchPoint.rotation * localOffset;

            GameObject missile = Instantiate(missilePrefab, launchPoint.position, finalRotation);
            Rigidbody rb = missile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = launchPoint.forward * launchForce;
            }
        }
    }

    void LateUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Asegura que la direcci�n sea horizontal
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
