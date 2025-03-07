// Gorney-Alex script

using UnityEngine;

public class GeneralMovements : MonoBehaviour
{
    private float maxSpeedFoward = 50f;
    private float maxSpeedBackward = 30f;
    private float acceleration = 1.5f;
    private float rotationSpeed = 30f;
    [SerializeField] private float currentSpeed = 0f;
    private float tiltSpeed = 1f;
    private float tiltAngle = 30f;

    private Vector3 movement = new Vector3();
    private bool direction = false;
    // false = foward, true = backwards
    [SerializeField] protected bool isGrounded = false;
    [SerializeField] protected GameObject carModel;
    [SerializeField] protected GameObject headLights;
    [SerializeField] protected Rigidbody rigidbodyCar;

    private void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody>();
    }

    public void MoveForward()
    {
        headLights.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        TiltCarModelFoward();
        if (currentSpeed >= 0f && direction == true)
        {
            currentSpeed -= Mathf.Lerp(currentSpeed, maxSpeedBackward, Time.fixedDeltaTime * acceleration);
            movement = transform.up * currentSpeed * Time.fixedDeltaTime;
            rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
        }
        direction = false;
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeedFoward, Time.fixedDeltaTime * acceleration);
        movement = -transform.up * currentSpeed * Time.fixedDeltaTime;
        rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
    }

    public void MoveBackward()
    {
        Color color = Color.red;
        headLights.GetComponent<Renderer>().material.SetColor("_EmissionColor", color * 3);
        headLights.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        TiltCarModelBackward();
        if (currentSpeed >= 0f && direction == false)
        {
            currentSpeed -= Mathf.Lerp(currentSpeed, maxSpeedBackward, Time.fixedDeltaTime * acceleration);
            movement = -transform.up * currentSpeed * Time.fixedDeltaTime;
            rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
        }
        direction = true;
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeedBackward, Time.fixedDeltaTime * acceleration);
        movement = transform.up * currentSpeed * Time.fixedDeltaTime;
        rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
    }

    public void SlowDown()
    {
        if (direction == false)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.fixedDeltaTime);
            movement = -transform.up * currentSpeed * Time.fixedDeltaTime;
            rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
            TiltCarModelStart();
        }
        else if (direction == true)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.fixedDeltaTime);
            movement = transform.up * currentSpeed * Time.fixedDeltaTime;
            rigidbodyCar.MovePosition(rigidbodyCar.position + movement);
            TiltCarModelStart();
        }
    }

    public void RotateLeft()
    {
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, -rotationSpeed * Time.fixedDeltaTime);
        rigidbodyCar.MoveRotation(rigidbodyCar.rotation * turnRotation);
        TiltCarModelLeft();
    }
    public void RotateRight()
    {
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
        rigidbodyCar.MoveRotation(rigidbodyCar.rotation * turnRotation);
        TiltCarModelRight();
    }

    public void CheckIfGrounded()
    {
        const int raycastDistance = 4;
        Debug.DrawRay(transform.position, -transform.forward * raycastDistance, Color.red);
        isGrounded = Physics.Raycast(transform.position, -transform.forward, raycastDistance);
    }
    public void TiltCarModelFoward()
    {
        Quaternion targetRotation = Quaternion.Euler(tiltAngle, 0f, 0f);
        carModel.transform.localRotation = Quaternion.Lerp(carModel.transform.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }
    public void TiltCarModelBackward()
    {
        Quaternion targetRotation = Quaternion.Euler(-tiltAngle, 0f, 0f);
        carModel.transform.localRotation = Quaternion.Lerp(carModel.transform.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }
    public void TiltCarModelStart()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
        carModel.transform.localRotation = Quaternion.Lerp(carModel.transform.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }
    public void TiltCarModelRight()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, tiltAngle, 0f);
        carModel.transform.localRotation = Quaternion.Lerp(carModel.transform.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }
    public void TiltCarModelLeft()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, -tiltAngle, 0f);
        carModel.transform.localRotation = Quaternion.Lerp(carModel.transform.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }

    public void CheckForWall()
    {
        const int rayDistance = 4;
        Debug.DrawRay(transform.position, -transform.up * rayDistance, Color.red);
        if (Physics.Raycast(transform.position, -transform.up, rayDistance))
        {
            currentSpeed = 0f;
            Debug.Log("Стена обнаружена!");
        }
    }
}
