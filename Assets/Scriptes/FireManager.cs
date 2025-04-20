using System.Collections;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] GameObject _Prefab; // نام متغیر اصلاح شد (تایپو اصلاح شد)
    [SerializeField] float fireRate = 0.5f; // زمان بین هر شلیک (قابل تنظیم در Inspector)
    private float nextFireTime = 0f;

    private void Update()
    {
        // فقط زمانی شلیک کن که زمان کنونی از زمان مجاز شلیک بعدی گذشته باشد
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            Instantiate(_Prefab, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate; // زمان شلیک بعدی را آپدیت کن
        }
    }
}
