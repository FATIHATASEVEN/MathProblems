using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karescript : MonoBehaviour
{
    [SerializeField]
    private GameObject karePrefab;
    [SerializeField]
    private Transform karelerPaneli;
    [SerializeField]
    private Text sorutext;
    private GameObject[] karelerdizisi = new GameObject[25];
    List<int> bolumdegerleriListesi = new List<int>();
    [SerializeField]
    private GameObject sonPanel;
    [SerializeField]
    private Sprite[] kareSprite;
    int bolunensayi, bolensayi;
    int kacincisoru;
    int butondegeri;
    bool butonaBasilsinmi;
    int dogrusonuc;
    int kalanHak;
    string sorununzorlukderecesi;
    HakScripts hak;
    puanScript puans;
    [SerializeField]
    private AudioSource audioSource;
    public AudioClip butonSesi;
    GameObject gecerlikare;
   
    private void Awake()
    {
        kalanHak = 3;
        audioSource = GetComponent<AudioSource>();
        sonPanel.SetActive(false);
        hak = Object.FindObjectOfType<HakScripts>();
        puans = Object.FindObjectOfType<puanScript>();
        hak.KalanHaklariKontrolEt(kalanHak);
    }
    void Start()
    {
        butonaBasilsinmi = false;
        kareleriolustur();
        Soru();
    }
    public void kareleriolustur()
    {
        for(int i=0;i<25;i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprite[Random.Range(0, kareSprite.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());
            karelerdizisi[i] = kare;
        }
        KarelereRandomDegerAtama();
    }
    public void ButonaBasildi()
    {
        audioSource.PlayOneShot(butonSesi);
        butondegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
        gecerlikare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Debug.Log(butondegeri);
        SonucuKontrolEt();
    }
    public void KarelereRandomDegerAtama()
    {
        foreach(var kare in karelerdizisi)
        {
            int rastgeledeger = Random.Range(1, 13);
            bolumdegerleriListesi.Add(rastgeledeger);
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeledeger.ToString();
        }
    }
    public void SonucuKontrolEt()
    {
        if(butondegeri == dogrusonuc)
        {
            gecerlikare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerlikare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerlikare.transform.GetComponent<Button>().interactable = false;
            puans.PuanArttir(sorununzorlukderecesi);
            bolumdegerleriListesi.RemoveAt(kacincisoru);
            
            if(bolumdegerleriListesi.Count>0)
            {
                SoruPaneliniAc();
            }
            else
            {
                OyunBitti();
            }     
        }
        else 
        {
            kalanHak--;
            hak.KalanHaklariKontrolEt(kalanHak);
        }
        if(kalanHak<=0)
        {
            OyunBitti();
        }
    }
    public void OyunBitti()
    {
        butonaBasilsinmi = false;
        sonPanel.SetActive(true);
    }
    public void SoruPaneliniAc()
    {
        Soru();
        butonaBasilsinmi = true;
    }
    public void Soru()
    {
        bolensayi=Random.Range(2,11);
        kacincisoru = Random.Range(0,bolumdegerleriListesi.Count);
        dogrusonuc = bolumdegerleriListesi[kacincisoru];
        bolunensayi = bolensayi*dogrusonuc;
        if(bolunensayi<=40)
        {
            sorununzorlukderecesi = "kolay";
        }
        else if(bolunensayi>40 && bolunensayi<=80)
        {
            sorununzorlukderecesi = "orta";
        }
        else
        {
            sorununzorlukderecesi = "zor";
        }
        sorutext.text =bolunensayi.ToString()+ " : " + bolensayi.ToString();
    }
}
 