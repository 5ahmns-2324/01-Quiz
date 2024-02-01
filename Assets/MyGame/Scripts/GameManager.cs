using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text frageText;
    public TMP_Text frageCountText;
    public TMP_Text countDown;
    public Button antwortOben;
    public Button antwortMitte;
    public Button antwortUnten;
    public Button weiterButton;
    public bool antwortObenRichtig;
    public bool antwortMitteRichtig;
    public bool antwortUntenRichtig;
    public int frageCountInt;


    private string frage1 = "Welche Farbe hat die Tafel in der Schulklasse?";
    private string frage2 = "Wer ist der Klassensprecher der 5AHMNS?";
    private string frage3 = "Was ist die beste Note in der Schule?";
    private string frage4 = "Wer betriebt das Buffet an der HTBLuVA Salzburg?";
    private string frage5 = "Was ist die Stammklasse der 5AHMNS?";

    List<string> fragenListe = new List<string>(5);

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("before " + fragenListe.Capacity);
        fragenListe.Add(frage1);
        //Debug.Log("Nach dem Ersten " + fragenListe.Capacity);
        fragenListe.Add(frage2);
        //Debug.Log("Nach dem Zweiten " + fragenListe.Capacity);
        fragenListe.Add(frage3);
        //Debug.Log("Nach dem Dritten " + fragenListe.Capacity);
        fragenListe.Add(frage4);
        //Debug.Log("Nach dem Vierten " + fragenListe.Capacity);
        fragenListe.Add(frage5);
        Debug.Log("after " + fragenListe.Capacity);

        for (int i = 0; i < fragenListe.Capacity; i++)
        {
            Debug.Log(fragenListe[i]);
        }


        frageCountInt = 1;
        

        frageText.text = fragenListe[Random.Range(0,4)];

        weiterButton.gameObject.SetActive(false);

        TafelFarbe();
    }

    void Update()
    {
        frageCountText.text = "Frage " + frageCountInt + " von 5";

        ChangeScene();

    }

    public void TafelFarbe()
    {
        if (frageText.text == fragenListe[0])
        {
            antwortOben.GetComponentInChildren<TMP_Text>().text = "grün";
            antwortMitte.GetComponentInChildren<TMP_Text>().text = "blau";
            antwortUnten.GetComponentInChildren<TMP_Text>().text = "weiß";

            antwortObenRichtig = true;
            antwortMitteRichtig = false;
            antwortUntenRichtig = false;
        }
    }

    public void Klassensprecher()
    {
        if (frageText.text == fragenListe[1])
        {
            antwortOben.GetComponentInChildren<TMP_Text>().text = "Fabian Rauch";
            antwortMitte.GetComponentInChildren<TMP_Text>().text = "Nico Zaussinger";
            antwortUnten.GetComponentInChildren<TMP_Text>().text = "Niklas Gruber";

            antwortObenRichtig = false;
            antwortMitteRichtig = true;
            antwortUntenRichtig = false;
        }
    }

    public void Schulnote()
    {
        if (frageText.text == fragenListe[2])
        {
            antwortOben.GetComponentInChildren<TMP_Text>().text = "3";
            antwortMitte.GetComponentInChildren<TMP_Text>().text = "2";
            antwortUnten.GetComponentInChildren<TMP_Text>().text = "1";

            antwortObenRichtig = false;
            antwortMitteRichtig = false;
            antwortUntenRichtig = true;
        }
    }

    public void Schulbuffet()
    {
        if (frageText.text == fragenListe[3])
        {
            antwortOben.GetComponentInChildren<TMP_Text>().text = "Erich";
            antwortMitte.GetComponentInChildren<TMP_Text>().text = "Günther";
            antwortUnten.GetComponentInChildren<TMP_Text>().text = "Harald";

            antwortObenRichtig = true;
            antwortMitteRichtig = false;
            antwortUntenRichtig = false;
        }
    }

    public void Stammklasse()
    {
        if (frageText.text == fragenListe[4])
        {
            antwortOben.GetComponentInChildren<TMP_Text>().text = "A305";
            antwortMitte.GetComponentInChildren<TMP_Text>().text = "A310";
            antwortUnten.GetComponentInChildren<TMP_Text>().text = "A312";

            antwortObenRichtig = false;
            antwortMitteRichtig = true;
            antwortUntenRichtig = false;
        }
    }

    public void ClickOnAnswer()
    {

        weiterButton.gameObject.SetActive(true);

        

        if (antwortObenRichtig)
        {
            antwortOben.image.color = Color.green;
            antwortMitte.image.color = Color.red;
            antwortUnten.image.color = Color.red;

            antwortOben.interactable = true;
            antwortMitte.interactable = false;
            antwortUnten.interactable = false;
        }

        if (antwortMitteRichtig)
        {
            antwortOben.image.color = Color.red;
            antwortMitte.image.color = Color.green;
            antwortUnten.image.color = Color.red;

            antwortOben.interactable = false;
            antwortMitte.interactable = true;
            antwortUnten.interactable = false;
        }

        if (antwortUntenRichtig)
        {
            antwortOben.image.color = Color.red;
            antwortMitte.image.color = Color.red;
            antwortUnten.image.color = Color.green;

            antwortOben.interactable = false;
            antwortMitte.interactable = false;
            antwortUnten.interactable = true;
        }
    }

    public void LoadNewQuestion()
    {
        frageCountInt++;
        weiterButton.gameObject.SetActive(false);
        
        int rnd = Random.Range(0, fragenListe.Capacity-1);
        //Debug.Log(fragenListe.Capacity);
        //Debug.Log(rnd);

        frageText.text = fragenListe[rnd];

        antwortOben.image.color = Color.white;
        antwortMitte.image.color = Color.white;
        antwortUnten.image.color = Color.white;

        antwortOben.interactable = true;
        antwortMitte.interactable = true;
        antwortUnten.interactable = true;
    }

    public void ChangeScene()
    {
        if (frageCountInt > 5)
        {
            SceneManager.LoadScene("wonScene");
        }
    }


    
}
