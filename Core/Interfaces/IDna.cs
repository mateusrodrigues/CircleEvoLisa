using GenArt.AST;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenArt.Core.Interfaces
{
    public interface IDna<T>
    {
        void Init();
        T Clone();
        void Mutate(IDnaDrawing drawing);
    }
}
