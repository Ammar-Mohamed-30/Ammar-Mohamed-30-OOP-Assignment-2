namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; } = "";
    public int Damage { get; set; }

    public Weapon Clone()
    {
        return new Weapon
        {
            Name = Name,
            Damage = Damage
        };
    }
}

public abstract class Enemy
{
    private string _modelData = "";

    public string Name { get; set; } = "";
    public int Health { get; set; }

    public Weapon Weapon { get; set; } = new();

    public List<string> Abilities { get; set; } = new();

    public string ModelId => _modelData;

    // يستخدم فقط عند إنشاء Prototype جديد
    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");

        Thread.Sleep(500);

        _modelData =
            "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    // يستخدم عند عمل Clone
    protected Enemy(Enemy prototype)
    {
        _modelData = prototype._modelData;

        Name = prototype.Name;
        Health = prototype.Health;

        // Deep Copy
        Weapon = prototype.Weapon.Clone();

        // Deep Copy للـList
        Abilities = new List<string>(prototype.Abilities);
    }

    public abstract Enemy Clone();
}

public class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;

        Weapon = new Weapon
        {
            Name = "Axe",
            Damage = 25
        };

        Abilities.Add("Rage");
    }

    private Orc(Orc prototype)
        : base(prototype)
    {
    }

    public override Enemy Clone()
    {
        return new Orc(this);
    }
}

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;

        Weapon = new Weapon
        {
            Name = "Bow",
            Damage = 18
        };

        Abilities.Add("Stealth");
    }

    private Elf(Elf prototype)
        : base(prototype)
    {
    }

    public override Enemy Clone()
    {
        return new Elf(this);
    }
}

public static class EnemyCopyHelper
{
    public static Enemy CopyEnemy(Enemy e)
    {
        return e.Clone();
    }
}