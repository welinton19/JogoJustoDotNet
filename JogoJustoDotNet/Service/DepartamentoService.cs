
using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class DepartamentoService : IDepartamendoService
{

    private readonly IDepartamentoRepositry _dprepositoy;

    public DepartamentoService(IDepartamentoRepositry dprepositoy)
    {
        _dprepositoy = dprepositoy;
    }

    void IDepartamendoService.AtualizarDepartamento(int id, string novoNome) => _dprepositoy.UpdateDepartamento(new DepartamentoModel { IdDepartamento = id, NomeDepartamento = novoNome });

    void IDepartamendoService.CriarDepartamento(string nome)=> _dprepositoy.CreateDepartamento(new DepartamentoModel { NomeDepartamento = nome });

    void IDepartamendoService.DeletarDepartamento(int id)
    {
        var departamento = _dprepositoy.GetDepartamentoById(id);
        if (departamento != null)
        {
            _dprepositoy.DeleteDepartamentoModel(departamento);
        }
    }

    DepartamentoModel IDepartamendoService.ObterDepartamentoPorId(int id)=> _dprepositoy.GetDepartamentoById(id);


    IEnumerable<DepartamentoModel> IDepartamendoService.ObterTodosDepartamentos()=> _dprepositoy.GetAllDepartamentos();

}
