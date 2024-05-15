using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField]
    float mainThrust = 1000f;
    [SerializeField]
    float rotationThrust = 100f;
    [SerializeField]
    AudioClip mainEngine;
    [SerializeField]
    ParticleSystem mainEngineParticles;
    [SerializeField]
    ParticleSystem leftSideThrusterParticles;
    [SerializeField]
    ParticleSystem rightSideThrusterParticles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

            PlayParticles(mainEngineParticles);
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
            PlayParticles(leftSideThrusterParticles);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
            PlayParticles(rightSideThrusterParticles);
        }
        else
        {
            leftSideThrusterParticles.Stop();
            rightSideThrusterParticles.Stop();
        }
    }

    private void ApplyRotation(Vector3 rotation)
    {
        transform.Rotate(rotation * rotationThrust * Time.deltaTime);
    }

    private void PlayParticles(ParticleSystem particleSystem)
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }
}
