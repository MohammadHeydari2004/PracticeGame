using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // موقعیت اولیه برای فعال کردن شیء
    [SerializeField] private float waitTime = 5f;  // زمان انتظار قبل از بازگشت شیء

    private void Start()
    {
        StartCoroutine(SpawnAndReturn());
    }

    private IEnumerator SpawnAndReturn()
    {
        while (true)
        {
            // 1. یک شیء از Pool بگیر
            GameObject obj = PoolManager.Instance.GetPooledObject();
            if (obj != null)
            {
                // 2. موقعیت شیء را تنظیم کن و فعال کن
                obj.transform.position = spawnPoint.position;
                obj.SetActive(true);

                // 3. 5 ثانیه منتظر بمان
                yield return new WaitForSeconds(waitTime);

                // 4. شیء را به Pool بازگردان
                PoolManager.Instance.ReturnToPool(obj);
            }

            // 5. بعد از 5 ثانیه، چرخه تکرار شود
            yield return null;
        }
    }
}