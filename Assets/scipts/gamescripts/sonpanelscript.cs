using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sonpanelscript : MonoBehaviour
{
   public void YenidenBasla()
    {
        SceneManager.LoadScene("gamelevel");
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("mainLevel");
    }
}
