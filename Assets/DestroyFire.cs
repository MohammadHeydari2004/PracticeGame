using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public ParticleSystem hitEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(hitEffectPrefab);
        }

    }

}