using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Log an event in Firebase Analytics (correct method)
        Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_1_DONE");

        // Correct Firebase database reference (fixed spelling mistake)
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Create the User object
        User user = new User("Rizwan", "bscs23140@itu.edu.pk");

        // Convert the User object to JSON
        string json = JsonUtility.ToJson(user);

        // Save the JSON to Firebase (correct method for async saving)
        reference.Child("users").Child("5").SetRawJsonValueAsync(json);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Fixed typo: use "Input" instead of "input"
        if (Input.acceleration.x > 0)
        {
            transform.Rotate(0, 1, 0);
        }
        else
        {
            transform.Rotate(0, 0, 1);
        }
    }

    // User class to represent the data to be stored in Firebase
    public class User
    {
        public string name;
        public string email;

        public User(string n, string e)
        {
            name = n;
            email = e;
        }
    }
}
