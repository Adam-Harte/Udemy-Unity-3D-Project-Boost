using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float mainThrust = 1000f;
    [SerializeField]
    float rotationThrust = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 rotation)
    {
        transform.Rotate(rotation * rotationThrust * Time.deltaTime);
    }
}
