using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Yatay hareket hızı
    public float jumpForce = 7f;  // Zıplama gücü
    private bool isGrounded = false; // Topun yere temas edip etmediğini kontrol eder
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D component'ini alıyoruz
    }

    void Update()
    {
        // Yatay hareket
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Zıplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Havaya çıktığı için zeminle temas yok
        }
    }

    // Platformlara temas ettiğinde yere basıyor mu diye kontrol eder
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish")) // Finish tag'ine sahip bir objeye çarparsa
        {
            LoadNextLevel(); // Yeni seviyeye geçiş yap
        }
    }

    // Yeni seviyeye geçiş yapan metot
    private void LoadNextLevel()
    {
        // Mevcut sahnenin indeksini al ve bir sonraki sahneye geç
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}



