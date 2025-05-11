using System.Collections.Generic;

[System.Serializable]
public class GameObj
{
    public int id;
    public string name;
    public string description;
}

[System.Serializable]
public class GameObjectsList
{
    public List<GameObj> GameObjects; // JSON’daki “GameObjects” ile birebir aynı
}
