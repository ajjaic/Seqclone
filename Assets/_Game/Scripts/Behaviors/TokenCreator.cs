using System;
using System.Collections;
using System.Collections.Generic;
using Sequence.Tokens;
using UnityEngine;

public class TokenCreator : MonoBehaviour
{
    [SerializeField] private PickAndPlace tokenObject;
    private PickAndPlace _createdToken;

    private void OnMouseDown()
    {
        _createdToken = Instantiate(tokenObject);
        _createdToken.OnMouseDown();
    }

    private void OnMouseUp()
    {
        _createdToken.OnMouseUp();
        _createdToken = null;
    }
}
