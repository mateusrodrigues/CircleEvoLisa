using GenArt.Classes;
using GenArt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GenArt.AST
{
    [Serializable]
    public class DnaCircleDrawing : IDnaDrawing
    {
        public List<DnaCircle> Circles { get; set; }

        [XmlIgnore]
        public bool IsDirty { get; private set; }

        public int PointCount
        {
            get
            {
                int pointCount = 0;
                foreach (DnaCircle circle in Circles)
                    pointCount++;

                return pointCount;
            }
        }

        public void SetDirty()
        {
            IsDirty = true;
        }

        public void Init()
        {
            Circles = new List<DnaCircle>();

            for (int i = 0; i < Settings.ActivePolygonsMin; i++)
                AddCircle();

            SetDirty();
        }

        public DnaCircleDrawing Clone()
        {
            var drawing = new DnaCircleDrawing
            {
                Circles = new List<DnaCircle>()
            };
            foreach (DnaCircle circle in Circles)
                drawing.Circles.Add(circle.Clone());

            return drawing;
        }


        public void Mutate()
        {
            if (Tools.WillMutate(Settings.ActiveAddPolygonMutationRate))
                AddCircle();

            if (Tools.WillMutate(Settings.ActiveRemovePolygonMutationRate))
                RemoveCircle();

            if (Tools.WillMutate(Settings.ActiveMovePolygonMutationRate))
                MoveCircle();

            foreach (DnaCircle circle in Circles)
                circle.Mutate(this);
        }

        public void MoveCircle()
        {
            if (Circles.Count < 1)
                return;

            int index = Tools.GetRandomNumber(0, Circles.Count);
            DnaCircle circ = Circles[index];
            Circles.RemoveAt(index);
            index = Tools.GetRandomNumber(0, Circles.Count);
            Circles.Insert(index, circ);
            SetDirty();
        }

        public void RemoveCircle()
        {
            if (Circles.Count > Settings.ActivePolygonsMin)
            {
                int index = Tools.GetRandomNumber(0, Circles.Count);
                Circles.RemoveAt(index);
                SetDirty();
            }
        }

        public void AddCircle()
        {
            if (Circles.Count < Settings.ActivePolygonsMax)
            {
                var newCircle = new DnaCircle();
                newCircle.Init();

                int index = Tools.GetRandomNumber(0, Circles.Count);

                Circles.Insert(index, newCircle);
                SetDirty();
            }
        }
    }
}
