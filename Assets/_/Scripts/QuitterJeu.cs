using UnityEngine;

public class QuitterJeu : MonoBehaviour
{
    // À brancher dans On Click () du bouton Quitter
    public void Quitter()
    {
#if UNITY_EDITOR
        // Dans l'éditeur : arrête le mode Play
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Dans le build (.exe) : ferme le jeu
        Application.Quit();
#endif
    }
}
