using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IConsultaRepository
    {
        List<Consulta> ListarConsultas();
        List<Consulta> ListarTodos();
        Consulta BuscarPorId(int id);
        void Cadastrar(Consulta novaConsulta);
        void Atualizar(int id, Consulta consultaAtualizada);
        void Deletar(int id);
    }
}
