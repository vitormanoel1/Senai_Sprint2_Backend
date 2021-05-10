using senai.inlock.webApi_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();

        TipoUsuarioDomain BuscarPorId(int Id);
    }
}
