using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] float timeTillDestroy = 3f;

    private void OnParticleSystemStopped()
    {
        Debug.Log($"Particle System Sopped at {name}");
    }

    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
