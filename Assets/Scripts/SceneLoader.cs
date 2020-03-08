using UnityEngine;

public class SceneLoader : MonoBehaviour
{
   [SerializeField] private string sceneToLoad;
   [SerializeField] private string sceneToUnload; 

   public void LoadScene()
   {
       Messenger<string>.Broadcast( "LoadScene", sceneToLoad );
   }

   public void UnLoadScene()
   {
       Messenger<string>.Broadcast( "UnLoadScene", sceneToUnload  );
   }
}
