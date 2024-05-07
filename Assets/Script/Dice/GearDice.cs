public class GearDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Growth;
    }

    

    void Upgrade()
    {
        if (Dice_category.Joker == category)
        {
            // 합체 로직
        }
    }
}
