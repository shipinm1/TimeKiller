using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatMenu : MonoBehaviour
{
    public Text fireRes;
    public Text coldRes;
    public Text health;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireRes.text = PlayerStats.instance.fireResist.GetValue().ToString();
        coldRes.text = PlayerStats.instance.coldResist.GetValue().ToString();
        health.text = PlayerStats.instance.health.GetValue().ToString();
    }

}
