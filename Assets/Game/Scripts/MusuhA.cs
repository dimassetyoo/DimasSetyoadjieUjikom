using UnityEngine;

public class MusuhA : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.gameObject.GetComponent<objPemain>().KurangNyawa();
        }
        if (!col.collider.CompareTag("Lantai"))
        {
            
        }

        // ✅ HANCUR hanya ketika menyentuh lantai
                Destroy(gameObject);
        
    }
}
