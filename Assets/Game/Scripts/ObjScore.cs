using UnityEngine; // Library utama Unity

public class ObjScore : MonoBehaviour
{
    // Start dipanggil sekali saat objek pertama kali aktif
    void Start()
    {
        // Tidak ada inisialisasi khusus di sini
    }

    // Update dipanggil setiap frame (tidak digunakan di script ini)
    void Update()
    {
        // Kosong karena tidak ada proses setiap frame
    }

    // Dipanggil saat objek ini bertabrakan dengan objek lain (Collider 2D dengan Rigidbody)
    void OnCollisionEnter2D(Collision2D col)
    {
        // Mengecek apakah objek yang menabrak memiliki tag "Player"
        if (col.collider.CompareTag("Lantai"))
        {
            // Mengambil script objPemain dari Player, lalu menjalankan fungsi TambahSkor()
            col.gameObject.GetComponent<objPemain>().TambahSkor();

            // Menampilkan pesan di Console untuk debugging
            Debug.Log("nambah skor");
        }
         if (col.collider.CompareTag("Peluru"))
        {
            // Mengambil script objPemain dari Player, lalu menjalankan fungsi TambahSkor()
            col.gameObject.GetComponent<objPemain>().TambahSkor();

            // Menampilkan pesan di Console untuk debugging
            Debug.Log("nambah skor");
        }

        // Menghancurkan objek ini setelah ditabrak (baik oleh player maupun objek lain)
        Destroy(gameObject);
    }
}
