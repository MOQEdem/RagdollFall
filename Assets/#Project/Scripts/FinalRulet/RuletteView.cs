using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuletteView : MonoBehaviour
{
   private TMP_Text _text;

   private void OnEnable()
   {
      _text = GetComponentInChildren<TMP_Text>();
   }
}
