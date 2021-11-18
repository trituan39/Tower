using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class facebookController : MonoBehaviour
{
    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    /*private void Start()
	{
        FB.Init(onInitComplete, onHideUnity);
	}*/
    /*private void onHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }*/
    /*private void onInitComplete()
    {
        if (FB.IsLoggedIn)
        {
            // Pause the game - we will need to hide
            print("fb is logged in");
        }
        else
        {
            // Resume the game - we're getting focus again
            print("fb is not logged in");
        }
    }*/

    public void FBLogin()
	{
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthLoginCallback);
        /*var permission = new List<string>();
        permission.Add("public_profile");
        FB.LogInWithReadPermissions(permission, AuthLoginCallback);*/
    }
    private void AuthLoginCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
        /*if (result.Error != null)
        {
            print(result.Error);
            return;
        }
        FB.API("/me", HttpMethod.GET, GetUserInfoCallback);*/
    }
   /* private void GetUserInfoCallback(IGraphResult result)
	{
        if(result.Error != null)
		{
            print(result.Error);
            return;
		}
        print(result);
	}*/
}