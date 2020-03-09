using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private List<string> sceneList;

    private void OnEnable()
    {
        Messenger<string>.AddListener( "LoadScene", LoadScene );
        Messenger<string>.AddListener( "UnLoadScene", UnLoadScene );
        Messenger<string>.AddListener( "SetActiveScene", SetActiveScene );
    }

    private void OnDisable()
    {
        Messenger<string>.RemoveListener( "LoadScene", UnLoadScene );
        Messenger<string>.RemoveListener( "UnLoadScene", UnLoadScene );
        Messenger<string>.RemoveListener( "SetActiveScene", SetActiveScene );

    }
   
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds( 2.0f );
        LoadScene( sceneList[0] );
    }

    private void LoadScene( string sceneToLoad )
    {
        SceneManager.LoadSceneAsync( sceneToLoad, LoadSceneMode.Additive);
    }

    private void UnLoadScene( string sceneToUnload )
    {
        SceneManager.UnloadSceneAsync( sceneToUnload );
    }

    private void SetActiveScene( string sceneToActivate )
    {
        SceneManager.SetActiveScene( SceneManager.GetSceneByName( sceneToActivate ) );
    }  
}
