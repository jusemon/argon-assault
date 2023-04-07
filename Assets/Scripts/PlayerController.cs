using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves upd and down based upon player input")]
    [SerializeField] float controlSpeedX = 50f;
    [SerializeField] float controlSpeedY = 50f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] ParticleSystem[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2.5f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;


    void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");
        ProcessTranslation(horizontalThrow, verticalThrow);
        ProcessRotation(horizontalThrow, verticalThrow);
        ProcessFiring();
    }

    private void ProcessTranslation(float horizontalThrow, float verticalThrow)
    {
        var xOffset = controlSpeedX * horizontalThrow * Time.deltaTime;
        var xRawPosition = transform.localPosition.x + xOffset;
        var xClamped = Mathf.Clamp(xRawPosition, -xRange, xRange);

        var yOffset = controlSpeedY * verticalThrow * Time.deltaTime;
        var yRawPosition = transform.localPosition.y + yOffset;
        var yClamped = Mathf.Clamp(yRawPosition, -yRange, yRange);

        transform.localPosition = new Vector3(
            xClamped,
            yClamped,
            transform.localPosition.z
        );
    }

    private void ProcessRotation(float horizontalThrow, float verticalThrow)
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (var laser in lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isActive;
        }

    }
}
