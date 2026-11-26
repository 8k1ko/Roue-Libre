using UnityEngine;
using TMPro;
using System.Collections;

// À mettre sur le panneau de message (Canvas). Affiche un message au début du niveau,
// avec un fondu, puis le cache après "duree" secondes.
[RequireComponent(typeof(CanvasGroup))]
public class MessageDebut : MonoBehaviour
{
    [TextArea(3, 6)]
    public string message = "";

    public TMP_Text texte;      // le texte TextMeshPro dans le panneau
    public float duree = 15f;   // secondes à l'écran
    public float fondu = 0.6f;  // durée du fondu (apparition / disparition)

    CanvasGroup groupe;

    IEnumerator Start()
    {
        groupe = GetComponent<CanvasGroup>();
        if (texte != null) texte.text = message;

        groupe.alpha = 0f;
        yield return Fondu(0f, 1f);
        yield return new WaitForSeconds(duree);
        yield return Fondu(1f, 0f);
        gameObject.SetActive(false);
    }

    IEnumerator Fondu(float de, float vers)
    {
        float t = 0f;
        while (t < fondu)
        {
            t += Time.deltaTime;
            groupe.alpha = Mathf.Lerp(de, vers, t / fondu);
            yield return null;
        }
        groupe.alpha = vers;
    }
}
