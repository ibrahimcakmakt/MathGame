using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;

    int puanSure = 10;
    bool sureBittimi = true;

    int toplamPuan, yazdirilicakPuan, artisPuani;
    private void Awake()
    {
        sureBittimi = true;
    }
    void Start()
    {
        
    }

    public void SonuclariGoster(int dogruAdet,int yanlisAdet,int puan)
    {
        dogruAdetText.text = dogruAdet.ToString();
        yanlisAdetText.text = yanlisAdet.ToString();
        puanText.text = puan.ToString();

        toplamPuan = puan;
        artisPuani = toplamPuan / 10;

        StartCoroutine(PuaniYazdirRoutine());
    }

    IEnumerator PuaniYazdirRoutine()
    {
        while (sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);

            yazdirilicakPuan += artisPuani;

            if (yazdirilicakPuan>=toplamPuan)
            {
                yazdirilicakPuan = toplamPuan;
            }

            puanText.text = yazdirilicakPuan.ToString();

            if (puanSure<=0)
            {
                sureBittimi = false;
            }

            puanSure--;
        }
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
