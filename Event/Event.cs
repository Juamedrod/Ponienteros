using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "MyEventAsset", order = 1)]
public class Event : ScriptableObject
{
    [Header("Description")]
    public Sprite icon;
    public new string name;
    public string description;
    public string seriousDescription;

    public Option option1;
    public Option option2;

 


    







}
