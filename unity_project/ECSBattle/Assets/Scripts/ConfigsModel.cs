using System;

[Serializable]
public class ConfigsModel
{
    public Config[] Configs;
}

[Serializable]
public class Config
{
    public TeamProperties TeamAProperties;
    public TeamProperties TeamBProperties;
    public int[] Units;
}

[Serializable]
public class TeamProperties
{
    public float HP;
    public float Attack;
    public float AttackSpeed;
    public float AttackRange;
    public float MovementSpeed;
}
