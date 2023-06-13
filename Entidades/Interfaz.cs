using System.Collections.Generic;

namespace Entidades
{
    public interface ISelecionar<T>
    {
        List<T> Selecionar();
    }
}