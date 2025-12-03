using System.Collections.Generic;
using UnityEngine;

public class KeyMapping
{
    public static readonly Dictionary<string, KeyCode> keyMap = new Dictionary<string, KeyCode>()
    {
        {"a", KeyCode.A}, 
        {"s", KeyCode.S}, 
        {"d", KeyCode.D}, 
        {"f", KeyCode.F}, 
        {"j", KeyCode.J}, 
        {"k", KeyCode.K}, 
        {"l", KeyCode.L}, 
        {";", KeyCode.Semicolon}, 
        {" ", KeyCode.Space}, 
    };
}