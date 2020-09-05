using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseManager : MonoBehaviour
{

    public DatabaseReference reference;
    public static FireBaseManager instance;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jumploop-9c669.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

    }


    public void AddDatabase(User user){
        
        //User user = new User("pç", 2);
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["score"] = user.score;
        result["username"] = user.username;
        reference.Child("datas").Child(user.username).SetValueAsync(result);
      
    }
}
