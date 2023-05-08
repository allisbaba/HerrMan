using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _text;
   [SerializeField] private AudioClip coinSound;
   
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("Collectibles"))
      {
        
         TotalPoint.totalPoint++;
         AudioSource.PlayClipAtPoint(coinSound, col.transform.position);
         Destroy(col.gameObject);
         _text.text = TotalPoint.totalPoint.ToString();
      }
   }
}
