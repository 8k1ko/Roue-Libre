using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// À mettre sur un objet qui a un collider "Is Trigger" (la zone d'interaction).
// Le joueur doit MAINTENIR la touche E : un cercle se remplit, puis l'événement part.
public class Interaction : MonoBehaviour
{
    [Header("Maintenir E pendant (secondes)")]
    public float tempsMaintien = 1.5f;

    [Header("Interface partagée (Invite_E)")]
    public GameObject invite;        // le groupe UI qui s'affiche près de l'objet
    public Image anneau;             // Image en mode Filled (le cercle qui se remplit)
    public RectTransform touche;     // l'icône de la touche E (elle "s'enfonce" quand on appuie)

    [Header("Condition (optionnelle)")]
    public bool requiertToutesLesPieces = false;
    public Inventaire inventaire;
    public GameObject messageManque; // ex. texte "Il manque des pièces"

    [Header("Quand le cercle est complet")]
    public UnityEvent quandTermine;

    bool joueurDedans;
    bool termine;
    float progression;

    void Update()
    {
        if (!joueurDedans || termine) return;

        bool permis = !requiertToutesLesPieces || (inventaire != null && inventaire.EstComplet);

        if (messageManque != null) messageManque.SetActive(!permis);
        if (invite != null) invite.SetActive(permis);

        bool appuie = permis && Keyboard.current != null && Keyboard.current.eKey.isPressed;

        if (appuie) progression += Time.deltaTime / tempsMaintien;
        else progression = 0f;

        MettreAJourUI(appuie);

        if (progression >= 1f)
        {
            termine = true;
            Cacher();
            quandTermine.Invoke();
        }
    }

    void MettreAJourUI(bool appuie)
    {
        if (anneau != null) anneau.fillAmount = progression;
        if (touche != null) touche.localScale = appuie ? Vector3.one * 0.85f : Vector3.one;
    }

    void Cacher()
    {
        progression = 0f;
        MettreAJourUI(false);
        if (invite != null) invite.SetActive(false);
        if (messageManque != null) messageManque.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) joueurDedans = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) joueurDedans = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        joueurDedans = false;
        Cacher();
    }
}
