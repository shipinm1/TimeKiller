using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FontTxt_Script : MonoBehaviour
{
    //reference to font text element
    public Text fontDemoTxt;
    public Text fontExtDemoTxt;
    public Text fontExtTitleTxt;

    public GameObject fontTxt;
    public GameObject fontExtText;
    public GameObject titleExtTxt;

    public GameObject fontCanvas;
    public GameObject mainCamera;
    public GameObject worldCamera;

    //set text at start 
    void Start()
    {
        mainCamera.SetActive(true);
        fontCanvas.SetActive(true);
        worldCamera.SetActive(false);
        fontDemoTxt.text = "\n JazzCreateCoolFont \n abcdefghijklm \n nopqrstuvwxyz \n 1234567890 \n ABCDEFGHIJKLM \n NOPQRSTUVWXYZ \n !#$%&'()*+,-./:;<=>?@ \n ^_`~¢£§©«»’—‘’•€";
        fontExtTitleTxt.text = "JazzCreateCoolFontExt";
        fontExtDemoTxt.text = " 193 Usable Characters " + "\n !#$%&'()*+,-./0123456789:;<=>?@ " + " ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^ \n _`abcdefghijklmnopqrstuvwxyz " +
"¢£¤¥©ª«®º»ÀÁÂÃÄÅÆÇ \n ÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß " + " àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ \n ŒœŠšŽžƒ•<>€™←↑→↓ \n ▲►▼◄☺☻☼♀♂♠♣♥♦♪♫ ";
        fontExtText.SetActive(false);
        titleExtTxt.SetActive(false);
        fontTxt.SetActive(true);
        StartFontDemo();
    }
    void StartFontDemo()
    {
        StopCoroutine("CycleFonts");
        StartCoroutine("CycleFonts");
    }

    IEnumerator CycleFonts()
    {
        yield return new WaitForSeconds(5);
        fontTxt.SetActive(false);
        fontExtText.SetActive(true);
        titleExtTxt.SetActive(true);
        yield return new WaitForSeconds(5);
        fontTxt.SetActive(false);
        fontExtText.SetActive(false);
        titleExtTxt.SetActive(false);
        mainCamera.SetActive(false);
        fontCanvas.SetActive(false);
        worldCamera.SetActive(true);
    }
    
}