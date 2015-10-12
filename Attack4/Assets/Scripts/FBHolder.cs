using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Facebook.Unity;


public class FBHolder : MonoBehaviour 
{
	public GameObject FBIsLoggedIn;
	public GameObject FBNotLoggedin;
	public GameObject uiFBAvatar;
	public GameObject uiFBUserName;

		
	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);
	}

	private void SetInit()
	{
		Debug.Log ("FB Init Done");
		if (FB.IsLoggedIn)
		{
			FBMenus(true);
		}
		else
		{
			FBMenus(false);
		}
	}

	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void FBLogin()
	{
		FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email" }, AuthCallBack);
	}

	void AuthCallBack(IResult result)
	{
		if (FB.IsLoggedIn)
		{
			FBMenus(true);
		}
		else
		{
			Debug.LogError("FB Login Failed");
			FBMenus(false);
		}
	}

	void FBMenus (bool isLoggedIn)
	{
		if (isLoggedIn)
		{
			FBIsLoggedIn.SetActive(true);
			FBNotLoggedin.SetActive(false);

			// get FB user profile picture
			FB.API("me/picture?g&width=128&height=128&redirect=false", HttpMethod.GET, GetPicture);

			// get FB user name
			FB.API("/me?fields=first_name", HttpMethod.GET, GetUserName);
		}
		else
		{
			FBIsLoggedIn.SetActive(false);
			FBNotLoggedin.SetActive(true);
		}
	}

	private void GetPicture(IGraphResult result)
	{

		if (result.Error == null)
		{
			IDictionary data = result.ResultDictionary["data"] as IDictionary;
			string photoURL = (string) data ["url"];

			StartCoroutine (FetchProfilePic (photoURL));
		}
		else
		{
			Debug.LogError(result.Error);
		}
	}

	private IEnumerator FetchProfilePic (string url)
	{
		WWW www = new WWW (url);
		yield return www;
		Image photo = uiFBAvatar.GetComponent<Image>();
		photo.sprite = Sprite.Create(www.texture, new Rect(0,0,128,128), Vector2.zero);

	}

	private void GetUserName (IGraphResult result)
	{
		if (result.Error == null)
		{

			uiFBUserName.GetComponent<Text>().text = "Hi " + result.ResultDictionary["first_name"].ToString();

		}
		else
		{
			Debug.LogError(result.Error);
		}
	}



	
}

