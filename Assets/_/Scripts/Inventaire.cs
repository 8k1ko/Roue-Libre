using UnityEngine;
using UnityEngine.Events;
using TMPro;

// Un seul objet "Inventaire" par niveau. Compte les pièces ramassées.
public class Inventaire : MonoBehaviour
{
    public int piecesRequises = 3;
    public TMP_Text texteCompteur;   // optionnel : affiche "Pièces : 0/3"
    public UnityEvent quandComplet;  // optionnel : ex. un son quand tout est ramassé

    int pieces;

    public bool EstComplet
    {
        get { return pieces >= piecesRequises; }
    }

    void Start()
    {
        Afficher();
    }

    // À brancher dans "Quand Termine" de chaque pièce
    public void AjouterPiece()
    {
        pieces++;
        Afficher();
        if (pieces == piecesRequises) quandComplet.Invoke();
    }

    void Afficher()
    {
        if (texteCompteur != null)
            texteCompteur.text = "Pièces : " + pieces + "/" + piecesRequises;
    }
}
