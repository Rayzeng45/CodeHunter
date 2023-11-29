using UnityEngine;

public class BackgroundMusicArea : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioClip backgroundMusicClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador entr� en el �rea, comienza a reproducir la m�sica de fondo
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador sali� del �rea, det�n la m�sica de fondo
            backgroundMusicSource.Stop();
        }
    }
}
