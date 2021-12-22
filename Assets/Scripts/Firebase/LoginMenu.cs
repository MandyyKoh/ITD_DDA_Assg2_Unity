/*Parts of this code have been referenced from user xzippyzach on Youtube.
Youtube Channel Link: https://www.youtube.com/channel/UChIh-0hvTYlwhqsdRWmtc7g */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginMenu : MonoBehaviour
{
    [Header("Login")]
    public TMP_InputField emailLoginInput;
    public TMP_InputField passwordLoginInput;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    [Header("Register")]
    public TMP_InputField usernameRegisterInput;
    public TMP_InputField emailRegisterInput;
    public TMP_InputField passwordRegisterInput;
    public TMP_InputField passwordRegisterConfirmInput;
    public TMP_Text warningRegisterText;

    [Header("ResetPassword")]
    public TMP_InputField resetPasswordEmailInput;
    public TMP_Text confirmResetPasswordText;
    public TMP_Text warningPasswordResetText;

    [Header("UI")]
    public GameObject loginMenu;
    public GameObject registerMenu;
    public GameObject mainMenu;

    public void LoginButton() 
    {
        FirebaseManager.instance.LoginFunction(emailLoginInput.text, passwordLoginInput.text);
    }

    public void RegisterButton() 
    {
        FirebaseManager.instance.RegisterFunction(emailRegisterInput.text, passwordRegisterInput.text, passwordRegisterConfirmInput.text,usernameRegisterInput.text);
    }

    public void ResetPasswordButton() 
    {
        FirebaseManager.instance.ResetPasswordFunction(resetPasswordEmailInput.text);
    }

    public void ClearLoginInput()
    {
        emailLoginInput.text = "";
        passwordLoginInput.text = "";
    }

    public void ClearRegisterInput()
    {
        usernameRegisterInput.text = "";
        emailRegisterInput.text = "";
        passwordRegisterInput.text = "";
        passwordRegisterConfirmInput.text = "";
    }
}
