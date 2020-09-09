using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Proyecto26;
using UnityEditor;
using System.Threading.Tasks;

public class FireBaseManager : MonoBehaviour
{
    public static FireBaseManager instance;

    DatabaseReference reference;

    public List<string> keyList = new List<string>();
    public List<string> urlList = new List<string>();
    public List<User> userList = new List<User>();
    public Dictionary<string, object> dict = new Dictionary<string, object>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {


        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jumploop-9c669.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        RetrieveDatabase();

        
    }
    /*public void AddDatabase(User user)
    {
        RestClient.Put("https://jumploop-9c669.firebaseio.com/" + user.username.ToString() + ".json", user);
    }*/


    /*public async void RetrieveDatabase()
    {
        
        await FirebaseDatabase.DefaultInstance.RootReference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;
                foreach (var item in snapshot.Children)
                {
                    keyList.Add(item.Key);
                }
                foreach (var key in keyList)
                {
                    urlList.Add("https://jumploop-9c669.firebaseio.com/" + key + ".json");
                }
            }
        });

        for (int i = 0; i < urlList.Count; i++)
        {
            Debug.Log(urlList[i]);
            RestClient.Get<User>(urlList[i]).Then(response =>
            {
                User user = new User(response.username, response.score);
                userList.Add(user);
            });
            
            await Task.Delay(1000);
            
        }
        await Task.WhenAll();
        Debug.Log("userlist count: "+userList.Count);
        for (int i = 0; i < userList.Count; i++)
        {
            Debug.Log(userList[i].username+" "+ userList[i].score);
        }
    }*/

    /*public async void RetrieveDatabase()
    {
        await RunAsync();
        
        Debug.Log(userList.Count);

        for (int i = 0; i < userList.Count; i++)
        {
            Debug.Log(userList[i].username+" "+ userList[i].score);
        }
        for (int i = 0; i < urlList.Count; i++)
        {
            Debug.Log(urlList[i]);
            RestClient.Get<User>(urlList[i]).Then(response =>
            {
                User user = new User(response.username, response.score);
                userList.Add(user);
            });
        }
    }*/

    /*public async Task RunAsync()
    {
        var tasks = new List<Task>();

        foreach (var url in urlList)
        {
            var task = DoSomethingAsync(url);
            tasks.Add(task);
        }

        await Task.WhenAll();
    }*/

    /*private async Task DoSomethingAsync(string url)
    {
        
        RestClient.Get<User>(url).Then(response =>
        {
            User user = new User(response.username, response.score);
            userList.Add(user);
        });
        await Task.Delay(2000);
    }*/

    public void AddDatabase(User user)
    {

        //User user = new User("pç", 2);
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["score"] = user.score;
        result["username"] = user.username;
        reference.Child(user.username).SetValueAsync(result);

    }

    public async void RetrieveDatabase()
    {
        await FirebaseDatabase.DefaultInstance.RootReference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                var dictionary = snapshot.Value as Dictionary<string, object>;
                if (dictionary != null)
                {
         
                    //dict = dictionary;
                    object value;
                    object sc, un;

                    string scS;
                    int scI;
                    
                    foreach (var key in dictionary.Keys)
                    {
                        dictionary.TryGetValue(key, out value);

                        var dict = value as Dictionary<string, object>;

                        dict.TryGetValue("score", out sc);
                        dict.TryGetValue("username", out un);
                        Debug.Log(un + " " + sc);

                        scS = sc.ToString();
                        scI = int.Parse(scS);

                        User user = new User(un.ToString(), scI);
                        userList.Add(user);

                    }
                }
            }
        });
    }
}
