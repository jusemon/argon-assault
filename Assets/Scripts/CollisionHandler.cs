using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private PlayerController playerController;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence(other);
    }

    private void StartCrashSequence(Collider other)
    {
        Debug.Log($"{name} triggered by {other.gameObject.name}");
        crashVFX.Play();
        playerController.enabled = false;
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        Invoke("ReloadScene", reloadDelay);
    }

    private void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
