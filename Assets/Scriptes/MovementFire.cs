using UnityEngine;

public class MovementFire : MonoBehaviour
{
    [SerializeField] float _Speed;
    void Update()
    {
        Vector3 vector = new(1, 0, 0);
        transform.position += _Speed * Time.deltaTime * vector;
    }
}
