using System.Collections;
using System.Collections.Generic;
using BonesOfTheFallen.Services.Graphics.Drawables;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics;

    public static class GameGraphics
    {
        internal static ICanvas GameCanvas = default!;
        internal static RectangleF rectangle = default!;
    }
    internal record DrawableFigure : IList<ISubDrawable>
    {
        internal readonly List<ISubDrawable> Drawables = new();
        internal IMainDrawable MainPoint = default!;

        public ISubDrawable this[int index] { get => ((IList<ISubDrawable>)Drawables)[index]; set => ((IList<ISubDrawable>)Drawables)[index] = value; }

        public int Count => ((ICollection<ISubDrawable>)Drawables).Count;

        public bool IsReadOnly => ((ICollection<ISubDrawable>)Drawables).IsReadOnly;

        public void Add(ISubDrawable item)
        {
            if (MainPoint == null)
            {
                MainPoint = (IMainDrawable)item;
            }
            else
            {
                ((ICollection<ISubDrawable>)Drawables).Add(item);
            }
        }

        public void Clear()
        {
            ((ICollection<ISubDrawable>)Drawables).Clear();
        }

        public bool Contains(ISubDrawable item)
        {
            return ((ICollection<ISubDrawable>)Drawables).Contains(item);
        }

        public void CopyTo(ISubDrawable[] array, int arrayIndex)
        {
            ((ICollection<ISubDrawable>)Drawables).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ISubDrawable> GetEnumerator()
        {
            return ((IEnumerable<ISubDrawable>)Drawables).GetEnumerator();
        }

        public int IndexOf(ISubDrawable item)
        {
            return ((IList<ISubDrawable>)Drawables).IndexOf(item);
        }

        public void Insert(int index, ISubDrawable item)
        {
            ((IList<ISubDrawable>)Drawables).Insert(index, item);
        }

        public bool Remove(ISubDrawable item)
        {
            return ((ICollection<ISubDrawable>)Drawables).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ISubDrawable>)Drawables).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Drawables).GetEnumerator();
        }
    }
    internal static class FigureExtensions
    {
        /// <summary>
        /// Operating on the First point(always the main point), allows other points to carry the offset from the main point.
        /// example : base of head + 1 = start of torso
        /// </summary>
        /// <param name="drawablePoints"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static DrawableFigure InitPointsTo(this DrawableFigure drawablePoints, float left, float top)
        {
            drawablePoints.MainPoint = (IMainDrawable)drawablePoints.MainPoint.MoveByOffset(left, top);
            for(int i = 0; i < drawablePoints.Drawables.Count; i++)
            {
                drawablePoints.Drawables[i] = drawablePoints.Drawables[i] switch
                {
                    DrawablePoint point => new DrawablePoint(left + point.Offset, top + point.Offset),
                    DrawableLine line => new DrawableLine(500, 520, line.Top, line.Orientation),
                    _ => throw new System.NotImplementedException(),
                };
            };
            return drawablePoints;
        }
        public static void DrawGroup(this DrawableFigure drawablePoints)
        {
            drawablePoints.Drawables.ForEach((x) => x.Draw(GameGraphics.GameCanvas, GameGraphics.rectangle));
        }
    }
    public record FigureContainer
    {
        internal static DrawableFigure GetFigure() => new();
        // gather figure DrawablePoints
        internal void SetFigure(DrawableFigure figure)
        {
            DrawableGroups.Add(figure);
        }
        private readonly List<DrawableFigure> DrawableGroups = new();
        internal DrawableFigure this[int index] {get => DrawableGroups[index]; set => DrawableGroups[index] = value;}
        public void DrawFigures()
        {
            foreach(var dg in DrawableGroups)
            {
                dg.MainPoint.Draw(GameGraphics.GameCanvas, GameGraphics.rectangle);
                dg.Drawables.ForEach((shape) => shape.Draw(GameGraphics.GameCanvas, GameGraphics.rectangle));
            }
        
        }
}


