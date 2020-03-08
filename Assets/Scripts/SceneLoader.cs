﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
   [SerializeField] private string sceneToLoad;
   [SerializeField] private string sceneToUnload; 

   public void LoadScene( string sceneToLoad )
   {
       Messenger<string>.Broadcast( "LoadScene", sceneToLoad );
   }

   public void UnLoadScene( string sceneToUnLoad )
   {
       Messenger<string>.Broadcast( "UnLoadScene", sceneToUnLoad );
   }
}