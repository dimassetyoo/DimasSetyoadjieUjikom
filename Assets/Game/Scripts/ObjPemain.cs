using TMPro;                        // Untuk teks UI menggunakan TextMeshPro
using UnityEngine;                 // Library utama Unity
using UnityEngine.UI;              // Untuk komponen UI seperti Image
using UnityEngine.SceneManagement; // Untuk pindah scene
using System;

public class objPemain : MonoBehaviour
{
    
    public bool isGrounded;         // Cek apakah pemain sedang menyentuh lantai
    public float health = 10;       // Nyawa pemain saat ini
    public int maxHealth;           // Nyawa maksimal (tidak digunakan)
    public int skor;                // Skor pemain saat ini
    public Vector2 mousePosition;   // Posisi gerakan pemain berdasarkan posisi mouse
    public Transform Prefab;
    public Image healthImage;       // UI gambar bar nyawa (fillAmount)
    public TMP_Text teksSkor;       // UI teks untuk menampilkan skor

    // Start dijalankan sekali saat game dimulai
    void Start()
    {
       
    }

    // Update dijalankan setiap frame
    void Update()
    {
        // Membatasi nilai health agar tidak kurang dari 0 dan tidak lebih dari 10
        health = Mathf.Clamp(health, 0, 10);
        if(Input.GetMouseButton(0))
        {
            Instantiate(Prefab, new Vector3(Input.mousePosition.x,- 0, 0), Quaternion.identity);
        } 
        move();        
    }

    // Fungsi untuk menggerakkan pemain secara horizontal mengikuti posisi mouse
    public void move()
    {
        // Ubah posisi mouse dari layar ke posisi dunia (world position)
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mengatur posisi x pemain mengikuti mouse, sedangkan posisi y tetap
        mousePosition = new Vector2(worldMousePosition.x, transform.position.y);

        // Batas minimum & maksimum layar agar pemain tidak keluar batas
        Vector2 minimum = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 maximum = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Membatasi posisi agar tetap di dalam layar
        mousePosition.x = Mathf.Clamp(mousePosition.x, minimum.x, maximum.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minimum.y, maximum.y);

        // Set posisi pemain ke posisi mouse yang sudah dibatasi
        transform.position = mousePosition;
    }

    // Fungsi mengurangi nyawa pemain
    public void KurangNyawa()
    {
        // Jika nyawa masih lebih dari 1 → pemain belum mati
        if (health > 1)
        {

            health = health - 1;                        // Kurangi nyawa
            healthImage.fillAmount = health / 10;       // Update bar nyawa
        }
        else
        {
            SceneManager.LoadScene("gameOver");         // Pindah ke scene game over
        }
    }

    // Fungsi menyimpan highscore
    
    public void TambahSkor()
    {
        skor = skor + 1;                         // Tambah skor
        teksSkor.text = "Skor : " + skor.ToString(); // Update UI skor
    }
}
