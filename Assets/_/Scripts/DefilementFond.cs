using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class DefilementFond : MonoBehaviour
{
    // Vitesse de défilement (positif = vers la gauche, négatif = vers la droite)
    public float vitesse = 0.05f;

    RawImage image;

    void Awake()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        Rect r = image.uvRect;
        r.x += vitesse * Time.deltaTime;
        image.uvRect = r;
    }
}
