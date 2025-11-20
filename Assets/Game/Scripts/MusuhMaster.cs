using UnityEngine;
using System.Collections;

public class MusuhMaster : MonoBehaviour
{
    public float SpawnInterval;
    public GameObject PrefabsObject;
    public bool isSpawning = true;
    public float minX;
    public float maxX;
    public Transform SpawnPosition;
    public float StartDelay;
    void Start()
    {
        HitungBatasLayar();
        StartCoroutine(StartSpawn());
    }

    // Update is called once per frame
    void HitungBatasLayar()
    {
       Camera cam = Camera.main;
       float jarakZ = Mathf.Abs(cam.transform.position.z);

       Vector3 kiri = cam.ScreenToWorldPoint(new Vector3(0,0, jarakZ));
       Vector3 kanan = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, jarakZ));

       minX = kiri.x;
       maxX = kanan.x;
    }
    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);           // Tentukan posisi X acak dalam batas layar
        Vector3 spawnPos = new Vector3(randomX, SpawnPosition.position.y, 0);

        int pilih = Random.Range(0, 5);                     // (Opsional) angka random jika ingin variasi object
        Instantiate(PrefabsObject, spawnPos, Quaternion.identity);  // Spawn object
    }
    IEnumerator SpawnObjectInterval()
    {
        // Coroutine untuk spawn terus-menerus sesuai interval tertentu
        while (isSpawning)
        {
            yield return new WaitForSeconds(SpawnInterval); // Tunggu interval waktu
            SpawnObject();                                  // Spawn object
        }
    }

    IEnumerator StartSpawn()
    {
        // Coroutine untuk delay sebelum spawn dimulai
        yield return new WaitForSeconds(StartDelay);        // Tunggu delay
        StartCoroutine(SpawnObjectInterval());              // Mulai spawn berulang
    }
}
