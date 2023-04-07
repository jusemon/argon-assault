using UnityEngine;

public class Enemy : MonoBehaviour
{

    private ScoreBoard scoreBoard;
    private Rigidbody rigidBody;
    private GameObject parent;
    [SerializeField] GameObject crashVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 5;

    private void Start()
    {
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(other.transform);
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit(Transform position)
    {
        hitPoints--;
        var vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(crashVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(gameObject);
    }
}
