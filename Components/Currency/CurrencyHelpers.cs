﻿namespace BonesOfTheFallen.Services.Components.Currency;

internal static class CurrencyHelpers
{
    internal static void AddCoin(this ref CurrencyBag bag, GameCurrencies currency, int count)
    {
        switch (currency)
        {
            case GameCurrencies.Gamium:
                bag.Gamiums += count;
                break;
            case GameCurrencies.Platinum:
                if (bag.PlatinumPieces + count < 1000)
                {
                    bag.PlatinumPieces += count;
                }
                else
                {
                    bag.PlatinumPieces += count - 1000;
                    bag.Gamiums++;
                }
                break;
            case GameCurrencies.Gold:
                if (bag.GoldPieces + count < 1000)
                {
                    bag.GoldPieces += count;
                }
                else
                {
                    bag.GoldPieces += count - 1000;
                    bag.PlatinumPieces++;
                }
                break;
            case GameCurrencies.Silver:
                if (bag.SilverPieces + count < 1000)
                {
                    bag.SilverPieces += count;
                }
                else
                {
                    bag.SilverPieces += count - 1000;
                    bag.GoldPieces++;
                }
                break;
            case GameCurrencies.Brass:
                if (bag.BrassPieces + count < 1000)
                {
                    bag.BrassPieces += count;
                }
                else
                {
                    bag.BrassPieces += count - 1000;
                    bag.SilverPieces++;
                }
                break;
            default:
                break;
        }
    }
    internal static bool SubCoin(this ref CurrencyBag bag, GameCurrencies currency, int count)
    {
        switch (currency)
        {
            case GameCurrencies.Gamium:
                if (bag.Gamiums > count)
                {
                    bag.Gamiums -= count;
                    return true;
                }
                break;
            case GameCurrencies.Platinum:
                if (bag.PlatinumPieces > count)
                {
                    bag.PlatinumPieces -= count;
                    return true;
                }
                else
                {
                    if(bag.Gamiums > 0)
                    {
                        bag.Gamiums--;
                        bag.PlatinumPieces += 1000 - count;
                        return true;
                    }    
                }
                break;
            case GameCurrencies.Gold:
                if (bag.GoldPieces > count)
                {
                    bag.GoldPieces-= count;
                    return true;
                }
                else
                {
                    if(bag.PlatinumPieces > 0)
                    {
                        bag.PlatinumPieces--;
                        bag.GoldPieces+= 1000 - count;
                        return true;
                    }
                }
                break;
            case GameCurrencies.Silver:
                if (bag.SilverPieces > count)
                {
                    bag.SilverPieces -= count;
                    return true;
                }
                else
                {
                    if(bag.GoldPieces > 0)
                    {
                        bag.GoldPieces--;
                        bag.SilverPieces += 1000 - count;
                        return true;
                    }
                }
                break;
            case GameCurrencies.Brass:
                if (bag.BrassPieces > count)
                {
                    bag.BrassPieces -= count;
                    return true;
                }
                else
                {
                    if(bag.SilverPieces > 0)
                    {
                        bag.SilverPieces--;
                        bag.BrassPieces += 1000 - count;
                        return true;
                    }
                }
                break;
            default:
                break;
        }
        return false;
    }
}
