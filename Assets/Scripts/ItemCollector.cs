using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Bananasnum;

    public Text BananasText;
    public AudioSource collectSound;
    void Start() 
    {
        Bananasnum = 0;
        BananasText.text = "Bananas : " + Bananasnum;
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        if(item.tag =="Collectable")
        {
            collectSound.Play();
            Destroy(item.gameObject);
            Bananasnum++;
            BananasText.text ="Bananas:"+ Bananasnum; 
        }
    }
    
    
}
