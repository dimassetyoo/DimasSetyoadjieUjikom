using UnityEngine;

public class ObjHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Cek apakah objek yang menabrak memiliki tag "Player"
        if (col.collider.CompareTag("Lantai"))
        {
            // Akses script objPemain pada Player, lalu panggil fungsi tambahNyawa()
            col.gameObject.GetComponent<objPemain>().KurangNyawa();

            // Tampilkan pesan di Console untuk debugging
            Debug.Log("kurang nyawa");
        }

        // Hancurkan objek health ini setelah ditabrak (baik oleh player atau objek lain)
        Destroy(gameObject);
}
}
