using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameTimeline : MonoBehaviour
{
    [Header("Configurazione")]
    public string sceneName; // Nome della scena da caricare
    public VideoPlayer videoPlayer; // Riferimento al componente VideoPlayer

    private void Start()
    {
        if (videoPlayer != null)
        {
            // Quando il video finisce, carica la nuova scena
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("VideoPlayer non assegnato nello script GameTimeline.");
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Il nome della scena non è stato impostato.");
        }
    }
}
