//using UnityEngine;

//public class FireManager : MonoBehaviour
//{
//    [SerializeField] private GameObject prefab;
//    [SerializeField] private float fireRate = 0.5f;
//    [SerializeField] private Transform Main_transform;

//    [Header("Audio")]
//    [SerializeField] private AudioSource audioSource;               // باید یک AudioSource داشته باشید
//    [SerializeField] private AudioClip fireClip;                    // کلیپ صدا
//    [SerializeField, Range(0f, 1f)] private float minVolume = 0f; // بازهٔ حجم صدا
//    [SerializeField, Range(0f, 1f)] private float maxVolume = 1f;
//    [SerializeField, Min(0.1f)] private float minPitch = -2.8f;      // بازهٔ زیر و بَم صدا
//    [SerializeField, Min(0.1f)] private float maxPitch = 3.2f;

//    private float nextFireTime = 0f;

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
//        {
//            Quaternion spawnRotation = Main_transform.rotation;
//            Instantiate(prefab, Main_transform.position, spawnRotation);
//            nextFireTime = Time.time + fireRate;

//            float rawVolume = Random.Range(minVolume, maxVolume);
//            float vol2dec = Mathf.Round(rawVolume * 100f) / 100f;

//            float rawPitch = Random.Range(minPitch, maxPitch);
//            float pitch1dec = Mathf.Round(rawPitch * 10f) / 10f;

//            audioSource.pitch = pitch1dec;
//            audioSource.PlayOneShot(fireClip, vol2dec);

//        }
//    }

//}

using UnityEngine;

public class FireManager : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Transform Main_transform;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireClip;
    [SerializeField, Range(0f, 1f)] private float minVolume = 0.0f;
    [SerializeField, Range(0f, 1f)] private float maxVolume = 1.0f;
    [SerializeField, Min(0.1f)] private float minPitch = -1f;
    [SerializeField, Min(0.1f)] private float maxPitch = 3f;

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            // 1. Instantiate the projectile using the Main_transform's position and rotation
            Instantiate(prefab, Main_transform.position, Main_transform.rotation);
            nextFireTime = Time.time + fireRate;

            // 2. Assign the audio clip and randomize volume and pitch
            audioSource.clip = fireClip;

            float rawVolume = Random.Range(minVolume, maxVolume);
            float volume = Mathf.Round(rawVolume * 100f) / 100f;

            float rawPitch = Random.Range(minPitch, maxPitch);
            float pitch = Mathf.Round(rawPitch * 10f) / 10f;

            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.Play();
        }
    }
}

