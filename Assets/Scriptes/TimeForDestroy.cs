using System.Collections;
using UnityEngine;

public class TimeForDestroy : MonoBehaviour
{
    [SerializeField] float Timer = 8;
    void Start()
    {
        StartCoroutine(DestroyColldown());
    }
    IEnumerator DestroyColldown()
    {
        yield return new WaitForSeconds(Timer);
        Destroy(gameObject);
    }
}
