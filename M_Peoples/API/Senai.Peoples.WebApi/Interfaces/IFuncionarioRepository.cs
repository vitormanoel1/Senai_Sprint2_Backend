using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FuncionarioRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista todos os funcionarios cadastrados
        /// </summary>
        /// <returns> Lista de funcionarios</returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// Buasca um funcionario pelo seu id
        /// </summary>
        /// <param name="IdFun"> Id do funcionario</param>
        /// <returns> Funcionario buscado por Id</returns>
        FuncionarioDomain BuscaPorId(int IdFun);

        /// <summary>
        /// Cadastra um funcionario
        /// </summary>
        /// <param name="NovoFuncionario"> Objeto com informações do funcionario que será cadastrado</param>
        void Cadastrar(FuncionarioDomain NovoFuncionario);

        /// <summary>
        /// Atualiza um usúario passando seu Id na url
        /// </summary>
        /// <param name="IdFun"> Id do funcionario</param>
        /// <param name="Funcionario"> Objeto funcionario com as informações atualizadas</param>
        void AtualizarIdUrl(int IdFun, FuncionarioDomain Funcionario);

        /// <summary>
        /// Deleta um funcionario pelo Id
        /// </summary>
        /// <param name="IdFun"> Id do funcionario</param>
        void Deletar(int IdFun);
    }
}
