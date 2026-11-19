using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScene : MonoBehaviour
{
    // Nom exact de la scène à charger (doit être dans la Scene List)
    public string nomDeLaScene = "Niveau1";

    // À brancher dans On Click () du bouton
    public void ChangeLaScene()
    {
        SceneManager.LoadScene(nomDeLaScene);
    }
}
