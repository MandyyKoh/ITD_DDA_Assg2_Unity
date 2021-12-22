/*Parts of this code have been referenced from user xzippyzach on Youtube.
Youtube Channel Link: https://www.youtube.com/channel/UChIh-0hvTYlwhqsdRWmtc7g */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;
using System.Linq;

public class FirebaseManager : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;
    public DatabaseReference dbReference;
    public string loggedInDisplayname;


    private int highestReportAccuracy;
    private float electricalShortestSolveTime = 999999f;
    private float bookshelfShortestSolveTime = 999999f;
    private float puzzleShortestSolveTime = 999999f;
    private float drawerShortestSolveTime = 999999f;
    private float paintingShortestSolveTime = 999999f;

    public GameObject loginMenu;

    public static FirebaseManager instance;
    private void Awake()
    {
        //Ensures there is only one audio manager at any time
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            dependencyStatus = task.Result;
            if(dependencyStatus == DependencyStatus.Available) 
            {
                IntializeFirebase();
            }
            else 
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void IntializeFirebase() 
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LoginFunction(string emailInput, string passwordInput) 
    {
        StartCoroutine(Login(emailInput, passwordInput));
    }

    public void RegisterFunction(string emailInput, string passwordInput, string passwordConfirmationInput, string usernameInput) 
    {
        StartCoroutine(Register(emailInput, passwordInput, passwordConfirmationInput, usernameInput));
    }

    public void ResetPasswordFunction(string emailInput) 
    {
        StartCoroutine(ResetPassword(emailInput));
    }

    /*void OnLoginLoaded(Scene scene, LoadSceneMode mode) 
    {
        if (scene.name == "Login")
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().ClearLoginInput();
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().ClearRegisterInput();
        }
    }*/

    /*public void SaveScoreButton() 
    {
        StartCoroutine(UpdateHighestScore());
        StartCoroutine(UpdateUsernameDatabase(loggedInDisplayname));

        if(PlayerPrefs.GetInt("totalAmount") > highestScore) 
        {
            StartCoroutine(UpdateScore(PlayerPrefs.GetInt("totalAmount")));
        }
    }*/

    public void UpdatePuzzleTime(string puzzleName, float time) 
    {
        StartCoroutine(CheckShortestSolveTime());
        float puzzleTimeToCheck = 999999f;
        if(puzzleName == "electricalTime") 
        {
            puzzleTimeToCheck = electricalShortestSolveTime;
        }
        else if(puzzleName == "bookshelfTime") 
        {
            puzzleTimeToCheck = bookshelfShortestSolveTime;
        }
        else if(puzzleName == "puzzleTime") 
        {
            puzzleTimeToCheck = puzzleShortestSolveTime;
        }
        else if (puzzleName == "drawerTime") 
        {
            puzzleTimeToCheck = drawerShortestSolveTime;
        }
        else if (puzzleName == "paintingTime") 
        {
            puzzleTimeToCheck = paintingShortestSolveTime;
        }
        if (time < puzzleTimeToCheck)
        {
            StartCoroutine(UploadPuzzleTime(puzzleName, time));
            Debug.Log("Time Uploaded");
        }
    }

    public void UpdateReportAccuracy(int reportAccuracy) 
    {
        StartCoroutine(CheckHighestReportAccuracy());
        if(reportAccuracy > highestReportAccuracy) 
        {
            StartCoroutine(UploadReportAccuracy(reportAccuracy));
        }
    }

    private void OpenLoginMenu() 
    {
        GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().loginMenu.SetActive(true);
        GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().registerMenu.SetActive(false);
    }

    private IEnumerator Login(string email, string password) 
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if(LoginTask.Exception != null) 
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseException = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseException.ErrorCode;

            string message = "Login Failed!";
            if (errorCode == AuthError.MissingEmail) 
            {
                message = "Missing Email";
            }
            else if(errorCode == AuthError.MissingPassword) 
            {
                message = "Missing Password";
            }
            else if(errorCode == AuthError.WrongPassword) 
            {
                message = "Wrong Password";
            }
            else if(errorCode == AuthError.InvalidEmail) 
            {
                message = "Invalid Email";
            }
            else if (errorCode == AuthError.UserNotFound) 
            {
                message = "Account does not exist";
            }
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningLoginText.text = message;
        }
        else 
        {
            user = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", user.DisplayName, user.Email);
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningLoginText.text = "";
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().confirmLoginText.text = "Logged In";

            loggedInDisplayname = user.DisplayName;
            loginMenu.GetComponent<LoginMenu>().mainMenu.SetActive(true);
            //SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator Register(string email, string password, string passwordConfirmation, string username) 
    {
        if(username == "") 
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningRegisterText.text = "Missing Username";
        }
        else if (password != passwordConfirmation)
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningRegisterText.text = "Passwords do not match!";
        }
        else 
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if(RegisterTask.Exception != null) 
            {
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseException = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseException.ErrorCode;

                string message = "Register Failed!";
                if(errorCode == AuthError.MissingEmail) 
                {
                    message = "Missing Email";
                }
                else if(errorCode == AuthError.MissingPassword) 
                {
                    message = "Missing Password";
                }
                else if(errorCode == AuthError.WeakPassword) 
                {
                    message = "Weak Password";
                }
                else if(errorCode == AuthError.EmailAlreadyInUse) 
                {
                    message = "Email already in use";
                }
                GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningRegisterText.text = message;

            }

            else 
            {
                user = RegisterTask.Result;

                if(user != null) 
                {
                    UserProfile profile = new UserProfile { DisplayName = username };

                    var ProfileTask = user.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if(ProfileTask.Exception != null) 
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseException = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseException.ErrorCode;
                        GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningRegisterText.text = "Username set failed!";
                    }
                    else 
                    {
                        OpenLoginMenu();
                        GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningRegisterText.text = "";
                    }
                }
            }
        }
    }

    private IEnumerator ResetPassword(string email) 
    {
        var DBTask = auth.SendPasswordResetEmailAsync(email);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.IsCanceled)
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningPasswordResetText.text = ("Password reset operation was cancelled.");
        }

        else if (DBTask.IsFaulted)
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningPasswordResetText.text = ("Password reset encountered an error.");
        }
        else
        {
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().confirmResetPasswordText.text = "Password reset email sent";
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().resetPasswordEmailInput.text = "";
            GameObject.Find("ApplicationForm").GetComponent<LoginMenu>().warningPasswordResetText.text = "";
        }
    }

    private IEnumerator UpdateUsernameDatabase(string username) 
    {
        var DBTask = dbReference.Child("users").Child(user.UserId).Child("username").SetValueAsync(username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
    }

    /*private IEnumerator UpdateScore(int score) 
    {

        var DBTask = dbReference.Child("users").Child(user.UserId).Child("score").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if(DBTask.Exception != null) 
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
    }*/

    private IEnumerator CheckShortestSolveTime() 
    {
        var DBTask = dbReference.Child("users").Child(user.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            electricalShortestSolveTime = 999999f;
            bookshelfShortestSolveTime = 999999f;
            puzzleShortestSolveTime = 999999f;
            drawerShortestSolveTime = 999999f;
            paintingShortestSolveTime = 999999f;

            /*StartCoroutine(UploadPuzzleTime("electricalTime", electricalShortestSolveTime));
            StartCoroutine(UploadPuzzleTime("bookshelfTime", bookshelfShortestSolveTime));
            StartCoroutine(UploadPuzzleTime("puzzleTime", puzzleShortestSolveTime));
            StartCoroutine(UploadPuzzleTime("drawerTime", drawerShortestSolveTime));
            StartCoroutine(UploadPuzzleTime("paintingTime", paintingShortestSolveTime));*/
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            electricalShortestSolveTime = float.Parse(snapshot.Child("electricalTime").Value.ToString());
            bookshelfShortestSolveTime = float.Parse(snapshot.Child("bookshelfTime").Value.ToString());
            puzzleShortestSolveTime = float.Parse(snapshot.Child("puzzleTime").Value.ToString());
            drawerShortestSolveTime = float.Parse(snapshot.Child("drawerTime").Value.ToString());
            paintingShortestSolveTime = float.Parse(snapshot.Child("paintingTime").Value.ToString());


        }
    }

    private IEnumerator UploadPuzzleTime(string puzzleName, float time)
    {

        var DBTask = dbReference.Child("users").Child(user.UserId).Child(puzzleName).SetValueAsync(time);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
    }

    private IEnumerator UploadReportAccuracy(int reportAccuracy)
    {

        var DBTask = dbReference.Child("users").Child(user.UserId).Child("reportAccuracy").SetValueAsync(reportAccuracy);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
    }

    private IEnumerator CheckHighestReportAccuracy()
    {
        var DBTask = dbReference.Child("users").Child(user.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            highestReportAccuracy = 0;
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            highestReportAccuracy = int.Parse(snapshot.Child("reportAccuracy").Value.ToString());

        }
    }





}
