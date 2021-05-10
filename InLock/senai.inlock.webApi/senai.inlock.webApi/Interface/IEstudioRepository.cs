using senai.inlock.webApi_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarPorEstudio(int id);
        List<EstudioDomain> ListarTodos();
        EstudioDomain BuscarPorId(int id);
        void Atualizar( int Id, EstudioDomain Estudio);
        void Cadastrar(EstudioDomain NovoEstudio);
        void Deletar(int Id);
    }
}
