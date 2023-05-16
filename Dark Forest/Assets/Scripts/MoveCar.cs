using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveCar : MonoBehaviour
{

    public float speed = 3f, rotateSpeed = 50f;
    public GameObject frontLights, backLights;
    private Rigidbody rb;
    private bool player = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * rotateSpeed * moveHorizontal * Time.fixedDeltaTime);
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical * speed);
        rb.MovePosition(transform.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);

        if (moveVertical > 0 && !frontLights)
            frontLights.SetActive(true);

        else if (moveVertical == 0 && frontLights)
            frontLights.SetActive(false);

        if (moveVertical < 0 && !backLights)
            backLights.SetActive(true);
        else if (moveVertical == 0 && backLights)
            backLights.SetActive(false);
    }

}