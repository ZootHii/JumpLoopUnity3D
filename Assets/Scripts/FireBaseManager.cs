/*using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections.Generic;
using UnityEngine;

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
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jumploop-1eb06.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        RetrieveDatabase();

    }

    public void AddDatabase(User user)
    {
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

                        scS = sc.ToString();
                        scI = int.Parse(scS);

                        User user = new User(un.ToString(), scI);
                        userList.Add(user);

                    }
                }
            }
        });
    }
}*/
