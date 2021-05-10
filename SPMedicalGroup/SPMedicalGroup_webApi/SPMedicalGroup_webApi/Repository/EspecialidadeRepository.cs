using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            // busca uma especialidade pelo seu id
            Especialidade especialidadeBuscado = ctx.Especialidades.Find(id);

            //  verifica se o nome da classe foi informado
            if (especialidadeAtualizada.NomeEspecialidade != null)
            {
                // atribui os novos valores aos campos existentes
                especialidadeBuscado.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
            }

            // atualiza a clinica que foi buscada
            ctx.Especialidades.Update(especialidadeBuscado);
            // salva a alteração no banco
            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            // retorna a especialidade buscada pelo seu id
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            // add uma nova especialidade
            ctx.Especialidades.Add(novaEspecialidade);
            // salva a informação no banco 
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca uma especialidade pelo seu id
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);
            // remove a clinica que foi buscada
            ctx.Especialidades.Remove(especialidadeBuscada);
            // salva a alteração no banco
            ctx.SaveChanges();
        }

        public List<Especialidade> ListarTodos()
        {
            // retorna uma lista 
            return ctx.Especialidades.ToList();
        }
    }
}
