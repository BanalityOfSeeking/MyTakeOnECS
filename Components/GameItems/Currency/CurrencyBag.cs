namespace BonesOfTheFallen.GameItems
{
    public readonly record struct CurrencyBag
    {
        public readonly int BrassPieces { get; init; } = 0;
        public readonly int SilverPieces { get; init; } = 0;
        public readonly int GoldPieces { get; init; } = 0;
        public readonly int SteelPieces { get; init; } = 0;
        public readonly int PlatinumPieces { get; init; } = 0;
        public readonly int Gamiums { get; init; } = 0;
    }
}