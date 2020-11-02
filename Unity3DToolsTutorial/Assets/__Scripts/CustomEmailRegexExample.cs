using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEmailRegexExample : MonoBehaviour
{
    [Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", "Invalid email address!\nExample: 'name@example.com'")]
    public string EmailAddress = "name@example.com";
}
