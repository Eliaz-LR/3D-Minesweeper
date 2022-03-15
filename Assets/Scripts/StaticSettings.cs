using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticSettings
{
   public static float mouseSensitivity{get; set;}


   static StaticSettings()
   {
      mouseSensitivity = 25;
   }
}
