
using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class DepartamentoService : IDepartamentoService
{

    private readonly IDepartamentoRepository _dprepositoy;

    public DepartamentoService(IDepartamentoRepository dprepositoy)
    {
        _dprepositoy = dprepositoy;
    }

    void IDepartamentoService.AtualizarDepartamento(int id, string novoNome) => _dprepositoy.UpdateDepartamento(new DepartamentoModel { IdDepartamento = id, NomeDepartamento = novoNome });

    void IDepartamentoService.CriarDepartamento(string nome)=> _dprepositoy.CreateDepartamento(new DepartamentoModel { NomeDepartamento = nome });

    void IDepartamentoService.DeletarDepartamento(int id)
    {
        var departamento = _dprepositoy.GetDepartamentoById(id);
        if (departamento != null)
        {
            _dprepositoy.DeleteDepartamentoModel(departamento);
        }
    }

    DepartamentoModel IDepartamentoService.ObterDepartamentoPorId(int id)=> _dprepositoy.GetDepartamentoById(id);


    IEnumerable<DepartamentoModel> IDepartamentoService.ObterTodosDepartamentos()=> _dprepositoy.GetAllDepartamentos();

}
