using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SocialButton : MonoBehaviour
{
    
    
    [SerializeField] private string whatURL;




    public void OpenURL() {
       
            Application.OpenURL(whatURL);

    }


    


}
