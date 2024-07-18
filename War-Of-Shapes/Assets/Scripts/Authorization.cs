using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Authorization : MonoBehaviour
{
    public Text status;

    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void signIn()
    {
        await signInAnonymous();
    }

    async Task signInAnonymous()
    {
        try
        {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
            print("sign in success");
            print("player ID:" + AuthenticationService.Instance.PlayerId);
            status.text = "Successful";

        }
        catch(System.Exception)
        {
            print("sign IN Failed!");
        }
    }
}
