using UnityEngine;
using UnityEngine.Video;

// Pour la scène de transition : la vidéo joue toute seule,
// puis le bouton "Niveau suivant" apparaît quand elle est finie.
public class VideoFinAfficheBouton : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject bouton;

    void Start()
    {
        // Le curseur était verrouillé dans le niveau : on le libère pour pouvoir cliquer
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (bouton != null) bouton.SetActive(false);
        videoPlayer.loopPointReached += QuandFini;
    }

    void QuandFini(VideoPlayer vp)
    {
        if (bouton != null) bouton.SetActive(true);
    }
}
