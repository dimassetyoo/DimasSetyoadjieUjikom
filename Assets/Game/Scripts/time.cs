using System.Collections;          // Menggunakan fitur IEnumerator dan Coroutine
using TMPro;                       // Untuk menggunakan TMP_Text
using UnityEngine;                 // Library utama Unity
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Untuk pindah scene

public class timer : MonoBehaviour
{
    public float time = 10f;       // Waktu awal countdown (dalam detik)
     public Image timeimage;     // Referensi ke UI teks untuk menampilkan timer
    public bool isCounting = true; // Status apakah timer masih berjalan atau tidak
    public objPemain objPemain;    // Referensi ke script pemain untuk ambil skor

    private Coroutine timerCoroutine; // Menyimpan coroutine timer yang sedang berjalan

    private void Start()
    {
        // Menampilkan waktu awal ke UI
        timeimage.fillAmount = time;

        // Memulai coroutine untuk menghitung mundur
        timerCoroutine = StartCoroutine(HitungTimer());
    }

    IEnumerator HitungTimer()
    {
        // Loop selama timer aktif dan waktu masih tersisa
        while (isCounting && time > 0)
        {
            yield return new WaitForSeconds(1f); // Tunggu 1 detik

            time -= 1;                                 // Kurangi waktu
            timeimage.fillAmount = time / 10; // Update teks di layar
        }

        // Jika waktu habis
        if (time <= 0)
        {
            isCounting = false;    // Matikan status hitung
            timeimage.fillAmount = time / 10; // Update teks di layar
        }
         }
    }
