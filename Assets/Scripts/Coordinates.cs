/*
    Author: Michael Latka
    ********************
    Coordinates Scriptable Object:
    ********************

    Is just two lists, keys and values, that are merged into a dictionary for quick reference
    Stores all the of zone positions on the board in one neat place for easy reference.
    
    NOTE: Originally had the two list system to allow the coordinates to be modified in the Unity Inspector, but scrapped that because Unity sucks and it provided
          no real advantage. Will clean this up when everything is better settled
*/
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewZoneCoordinates", menuName = "Coordinates/ZoneCoordinateDictionary")]
public class Coordinates : ScriptableObject
{
    // Init lists for keys and values
    private List<string> keys;
    private List<Vector3> values;
    private Dictionary<string, Vector3> coordinatesDictionary; // Define the actual dictionary for O(1) reference
    
    public void Initialize()
    {   
        keys = new List<string>();
        values = new List<Vector3>();
        keys.Add("p1DeckZone");
        values.Add(new Vector3(-14, -8, -0.7f));
        keys.Add("p1UnitZone1");
        values.Add(new Vector3(-8, -6, -0.7f));
        keys.Add("p1UnitZone2");
        values.Add(new Vector3(-4, -6, -0.7f));
        keys.Add("p1UnitZone3");
        values.Add(new Vector3(0, -6, -0.7f));
        keys.Add("p1UnitZone4");
        values.Add(new Vector3(4, -6, -0.7f));
        keys.Add("p1UnitZone5");
        values.Add(new Vector3(8, -6, -0.7f));
        keys.Add("p1DiscardZone");
        values.Add(new Vector3(14, -3, -0.7f));
        keys.Add("p1ExileZone");
        values.Add(new Vector3(18, -1, -0.7f));
        keys.Add("p1PrismaticZone");
        values.Add(new Vector3(16, -8, -0.7f));
        keys.Add("p1CombatZone");
        values.Add(new Vector3(-8, -2, -0.7f));
        keys.Add("p1HandZone");
        values.Add(new Vector3(-4, -10, -0.7f));

        keys.Add("p2DeckZone");
        values.Add(new Vector3(14, 8, -0.7f));
        keys.Add("p2UnitZone1");
        values.Add(new Vector3(-8, 6, -0.7f));
        keys.Add("p2UnitZone2");
        values.Add(new Vector3(-4, 6, -0.7f));
        keys.Add("p2UnitZone3");
        values.Add(new Vector3(0, 6, -0.7f));
        keys.Add("p2UnitZone4");
        values.Add(new Vector3(4, 6, -0.7f));
        keys.Add("p2UnitZone5");
        values.Add(new Vector3(8, 6, -0.7f));
        keys.Add("p2DiscardZone");
        values.Add(new Vector3(-14, 3, -0.7f));
        keys.Add("p2ExileZone");
        values.Add(new Vector3(-18, 1, -0.7f));
        keys.Add("p2PrismaticZone");
        values.Add(new Vector3(-16, 8, -0.7f));
        keys.Add("p2CombatZone");
        values.Add(new Vector3(-8, 2, -0.7f));
        keys.Add("p2HandZone");
        values.Add(new Vector3(-4, 10, -0.7f));
        // Init the dict and assign the key value pairs
        coordinatesDictionary = new Dictionary<string, Vector3>();

        for (int i = 0; i < keys.Count; i++)
        {
            if (i < values.Count)
            {
                coordinatesDictionary[keys[i]] = values[i];
            }
        }
    }

    public Vector3 GetCoordinate(string key)
    {
        // returns the value from a given key from the dict
        if (coordinatesDictionary == null)
        {
            Initialize();
        }

        if (coordinatesDictionary.TryGetValue(key, out Vector3 value))
        {
            return value;
        }

        Debug.LogWarning("Key not found: " + key);
        return Vector3.zero; // returns the 0 coord if nothing found
    }

    // Returns the players coordinated given their player number
    // NOTE: This will have to change to accomate the network player system. Im doing it like this because
    // the number of zones will most likely not change and if they do its a simple enough tweak to the numbers here
    public List<Vector3> GetPlayerCoords(int playerNum)
    {
        List<Vector3> playercoords = new List<Vector3>();
        if(playerNum == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                playercoords.Add(values[i]);
            }
        } else {
            for (int i = 11; i < 22; i++)
            {
                playercoords.Add(values[i]);
            }
        }
        return playercoords;
    }
}