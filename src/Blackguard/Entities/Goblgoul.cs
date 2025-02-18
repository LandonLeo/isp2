namespace Blackguard.Entities;

public class Goblgoul : EntityDefinition {
    public Goblgoul() {
        Glyph = 'G';
        Name = "Goblgoul";

        MaxHealth = 75;
        MaxMana = 30;
        MaxSpeed = 100;
        BluntEffect = 1;
        SlashEffect = 1;
        PierceEffect = 1.5;
        MagicEffect = 1;
        BaseEffect = 1;
        FireEffect = 1;
        ElectricityEffect = 1;
        IceEffect = 1.5;
        WaterEffect = 1.5;
        EarthEffect = 1.5;
        MindEffect = 1.5;
    }
}
