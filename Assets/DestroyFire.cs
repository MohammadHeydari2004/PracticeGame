using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public ParticleSystem hitEffectPrefab;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        // افکت برخورد رو فوراً نشون می‌دیم
    //        ParticleSystem effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
    //        effect.Play();

    //        // غیرفعال کردن دشمن و لیزر (برای اینکه دیگه دیده نشن یا با چیزی برخورد نکنن)
    //        collision.gameObject.SetActive(false);
    //        gameObject.SetActive(false);

    //        // بعد از ۱ ثانیه حذف کامل همه‌چیز
    //        StartCoroutine(DestroyAll(effect.gameObject, collision.gameObject, this.gameObject, 1f));
    //    }
    //}

    //private System.Collections.IEnumerator DestroyAll(GameObject effect, GameObject enemy, GameObject laser, float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    Destroy(effect);
    //    Destroy(enemy);
    //    Destroy(laser);
    //}
    //// Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }

}
