using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadeTime;
    private bool crit;
    public AnimationClip critAnimation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //stop the text from moving when doing the critical animation

        //Debug.Log(crit);
       // if (!crit)
        //{
            float translation = speed * Time.deltaTime;
            transform.Translate(translation * direction);
       // }
        
	}

    public void InitialialCombatText(float speed, Vector3 direction, float fadeTime, bool crit)
    {
        this.speed = speed;
        this.direction = direction;
        this.fadeTime = fadeTime;
        this.crit = crit;
        //if critical strick then do critical coroutine
        if (crit)
        {
            //play critical animation
            GetComponent<Animator>().SetTrigger("Critical");
            crit = false;
            StartCoroutine(CritText());
        }
        else
        {
            StartCoroutine(FadeText());
        }
    }

    private IEnumerator CritText()
    {
        //wait for the critical animation play first
        yield return new WaitForSeconds(critAnimation.length);
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        float startAlpha = GetComponent<Text>().color.a;
        //fading rate
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;
        while (progress < 1.0)
        {
            Color temp = GetComponent<Text>().color;
            GetComponent<Text>().color = new Color(temp.r, temp.g, temp.b, Mathf.Lerp(startAlpha, 0, progress));
            //update the progress
            progress += rate * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
