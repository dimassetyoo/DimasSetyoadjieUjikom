using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void aksiCredit()
    {
        // Pindah ke scene Credit
        SceneManager.LoadScene("Credit");
    }
    public void aksiPlay()
    {
        // Pindah ke scene Credit
        SceneManager.LoadScene("GamePlay");
    }
    public void aksiMenu()
    {
        // Pindah ke scene Credit
        SceneManager.LoadScene("MainMenu");
    }

    public void aksiExit()
    {

        // Keluar aplikasi (berfungsi hanya pada build, bukan di editor)
        Application.Quit();
    }
}
