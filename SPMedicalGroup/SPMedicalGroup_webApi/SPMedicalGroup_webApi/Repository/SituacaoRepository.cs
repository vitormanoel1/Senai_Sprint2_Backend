using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class SituacaoRepository : ISituacaoRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);

            if (situacaoAtualizada.Situacao1 != null)
            {
                situacaoBuscada.Situacao1 = situacaoAtualizada.Situacao1;
            }

            ctx.Situacaos.Update(situacaoBuscada);
            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(s => s.IdSituacao == id);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);
            ctx.Situacaos.Remove(situacaoBuscada);
            ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
