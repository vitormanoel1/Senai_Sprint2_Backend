using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IClinicaRepository
    {
        /// <summary>
        /// lista todas as clinicas
        /// </summary>
        /// <returns> retorna uma lista</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// busca uma clinica através do seu id
        /// </summary>
        /// <param name="id"> id da clinica que será buscada </param>
        /// <returns> uma clinica buscada</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica"> objeto chamado novaClinica que será cadastrada</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// atualiza uma clinica existente
        /// </summary>
        /// <param name="id"> id da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada"> objeto clinicaAtualizada com as novas informações</param>
        void Atualizar(int id, Clinica clinicaAtualizada);

        /// <summary>
        /// deleta uma clinica existente 
        /// </summary>
        /// <param name="id"> id da clinica que será deletada</param>
        void Deletar(int id);
    }
}
