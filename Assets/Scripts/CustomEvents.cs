using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class VoidEvent : UnityEvent { }
[Serializable] public class BoolEvent : UnityEvent<bool> { }
[Serializable] public class IntEvent : UnityEvent<int> { }
[Serializable] public class StringEvent : UnityEvent<string> { }
[Serializable] public class CropEvent : UnityEvent<Crop> { }