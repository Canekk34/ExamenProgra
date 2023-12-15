using UnityEngine;

public class ApllyMat : MonoBehaviour
{

    [SerializeField] private MatColor color;
    private Material mat;


    private void Start()
    {
        Debug.Log(color);
        mat = GetComponent<Material>();

        Renderer renderer = GetComponent<Renderer>();
        mat = renderer.material;

        ChangeMatColor();
    }

    private void OnValidate()
    {
        if (mat != null)
        {
            ChangeMatColor();
        }
    }

    private void ChangeMatColor()
    {
        
        switch (color)
        {

            case MatColor.Red:
                {
                    mat.color = Color.red;
                    break;
                }

            case MatColor.Blue:
                {
                    mat.color = Color.blue;
                    break;
                }

            case MatColor.Green:
                {
                    mat.color = Color.green;
                    break;
                }

            case MatColor.Yellow:
                {
                    mat.color = new Color(1,0.92f,0.16f); // r g b
                    break;
                }

            case MatColor.Pink:
                {
                    mat.color = new Color(1, .6f, .7f);
                    break;
                }

            case MatColor.Orange:
                {
                    mat.color = new Color(1, .5f, 0f);
                    break;
                }

            case MatColor.Brown:
                {
                    mat.color = new Color(.5f, .2f, .07f);
                    break;
                }

            case MatColor.Purple:
                {
                    mat.color = new Color(.5f, 0f, .9f);
                    break;
                }

            case MatColor.Black:
                {
                    mat.color = new Color(0f, 0f, 0f);
                    break;
                }

            case MatColor.White:
                {
                    mat.color = new Color(1, 1f, 1f);
                    break;
                }
        }

    }

}
