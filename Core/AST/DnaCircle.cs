using GenArt.Classes;
using GenArt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenArt.AST
{
    public class DnaCircle : IDna<DnaCircle>
    {
        public DnaPoint Center { get; set; }
        public int Radius { get; set; }
        public DnaBrush Brush { get; set; }

        public DnaCircle Clone()
        {
            var newCircle = new DnaCircle
            {
                Center = new DnaPoint(),
                Brush = Brush.Clone(),
                Radius = this.Radius
            };
            return newCircle;
        }

        public void Init()
        {
            Center = new DnaPoint();
            Center.Init();

            // TODO: Test random number
            Radius = Tools.GetRandomNumber(0, Tools.MaxWidth);

            Brush = new DnaBrush();
            Brush.Init();
        }

        public void Mutate(IDnaDrawing drawing)
        {
            // TODO: Implement circle mutation
        }
    }
}
