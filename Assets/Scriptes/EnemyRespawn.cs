using System.Collections;
using UnityEngine;
public class EnemyRespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Respawn());
    }
    [SerializeField] GameObject _Enemy;
    [SerializeField] float _Rotation_Y = 180;
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Respawn()
    {
        float _x = Random.Range(2f, 10f);
        float _y = Random.Range(0f, 4f);
        float _z = gameObject.transform.position.z;
        Quaternion quaternion = new(0, _Rotation_Y, 0, 0);
        Vector3 vector = new(_x, _y, _z);
        Instantiate(_Enemy, vector, quaternion);
        yield return new WaitForSeconds(2);
        StartCoroutine(Respawn());
    }
}
