using System;
using System.Collections.Generic;
using System.Text;

namespace GenArt.Core.Interfaces
{
    public interface IDnaDrawing
    {
        int PointCount { get; }
        void SetDirty();
    }
}
