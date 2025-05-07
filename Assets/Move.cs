using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minAngle = 0f;     // حداقل زاویه (0 درجه)
    [SerializeField] private float maxAngle = 180f;   // حداکثر زاویه (180 درجه)
    [SerializeField] private float directionChangeInterval = 5f; // تاخیر بین تغییر جهت (5 ثانیه)

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float lastDirectionChangeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GenerateRandomDirection(); // جهت اولیه
        lastDirectionChangeTime = Time.time;
    }

    void Update()
    {
        // 1. بررسی زمان برای تغییر جهت
        if (Time.time - lastDirectionChangeTime >= directionChangeInterval)
        {
            GenerateRandomDirection(); // تولید جهت جدید
            lastDirectionChangeTime = Time.time; // بازنگرداندن زمان
        }

        // 2. اعمال حرکت
        rb.linearVelocity = movementDirection * speed;

        // 3. چرخش به سمت جهت حرکت
        if (movementDirection.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2( -movementDirection.x , movementDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void GenerateRandomDirection()
    {
        // تولید زاویه تصادفی بین 0 تا 180 درجه
        float randomAngle = Random.Range(minAngle, maxAngle);
        float radian = randomAngle * Mathf.Deg2Rad;

        // محاسبه جهت بردار حرکت
        movementDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}