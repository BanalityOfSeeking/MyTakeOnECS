namespace BonesOfTheFallen.Services.Components.Interfaces;

public delegate ref T ComponentRefAction<T>(ref T component) where T : IComponentBase;
