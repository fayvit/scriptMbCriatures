using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MapaPorSript : MonoBehaviour
{
    public Texture2D img;
    public GameObject blocoDeGrama;
    public GameObject blocoDeTerra;
    public GameObject blocoComTijoloes;

    public bool vai;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vai)
        {
            for (int i = 0; i < img.width; i++)
                for (int j = 0; j < img.height; j++)
                {
                    ColoqueBLoco(img.GetPixel(i, j), i, j);
                }
            vai = false;
        }
    }

    void ColoqueBLoco(Color C, int x, int y)
    {
        GameObject G;
        if (C.r != 0)
            Debug.Log(C);

        
            if(C== Color.red)
                G = blocoDeTerra;
            else
            if(C==Color.blue)
                G = blocoComTijoloes;
            else
                G = blocoDeGrama;
            
        

        Instantiate(G, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
    }
}
