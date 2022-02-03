namespace BonesOfTheFallen.GameItems
{
    internal static class CurrencyHelpers
    {
        internal static void AddCoin(this ref CurrencyBag bag, GameCurrencies currency, int count)
        {
            switch (currency)
            {
                case GameCurrencies.Gamium:
                    bag = bag with { Gamiums = bag.Gamiums + count };
                    break;
                case GameCurrencies.Platinum:
                    if (bag.PlatinumPieces + count < 1000)
                    {
                        bag = bag with { PlatinumPieces = bag.PlatinumPieces + count };
                    }
                    else
                    {
                        bag = bag with { PlatinumPieces = bag.PlatinumPieces + count - 1000 };
                        AddCoin(ref bag, GameCurrencies.Gamium, 1);
                    }
                    break;
                case GameCurrencies.Gold:
                    if (bag.GoldPieces + count < 1000)
                    {
                        bag = bag with { GoldPieces = bag.GoldPieces + count };
                    }
                    else
                    {
                        bag = bag with { GoldPieces = bag.GoldPieces + count - 1000 };
                        AddCoin(ref bag, GameCurrencies.Platinum, 1);
                    }
                    break;
                case GameCurrencies.Silver:
                    if (bag.SilverPieces + count < 1000)
                    {
                        bag = bag with { SilverPieces = bag.SilverPieces + count };
                    }
                    else
                    {
                        bag = bag with { SilverPieces = bag.SilverPieces + count - 1000 };
                        AddCoin(ref bag, GameCurrencies.Gold, 1);
                    }
                    break;
                case GameCurrencies.Brass:
                    if (bag.BrassPieces + count < 1000)
                    {
                        bag = bag with { BrassPieces = bag.BrassPieces + count };
                    }
                    else
                    {
                        bag = bag with { BrassPieces = bag.BrassPieces + count - 1000 };
                        AddCoin(ref bag, GameCurrencies.Silver, 1);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}