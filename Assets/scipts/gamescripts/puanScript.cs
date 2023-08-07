using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puanScript : MonoBehaviour
{
    public int toplamPuan;
    public int puanArtisi;

    [SerializeField]
    private Text puanText;  

    void Start()
    {
        puanText.text = toplamPuan.ToString();
    }
   public void PuanArttir(string zorlukseviyesi)
    {
        switch (zorlukseviyesi)
        {
            case "kolay":
                puanArtisi = 5;
                break;
            case "orta":
                puanArtisi = 10;
                break;
            case "zor":
                puanArtisi = 15;
                break;
        }
        toplamPuan += puanArtisi;
        puanText.text = toplamPuan.ToString();

    }
}
