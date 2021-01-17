using System;
using System.Collections.Generic;
using System.Text;
using TempElementsLib.Interfaces;

namespace TempElementsLib.src.classes
{
    class TempElementsStack : ITempElements
    {
        public IReadOnlyCollection<ITempElement> Elements => throw new NotImplementedException();

        public T AddElement<T>() where T : ITempElement, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RemoveDestroyed()
        {
            throw new NotImplementedException();
        }
    }
}
