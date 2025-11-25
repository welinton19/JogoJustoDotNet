
using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class DepartamentoService : IDepartamentoService
{

    private readonly IDepartamentoRepository _dprepository;

    public DepartamentoService(IDepartamentoRepository dprepository)
    {
        _dprepository = dprepository;
    }

    public void AtualizarDepartamento(int id, string novoNome) => _dprepository.UpdateDepartamento(new DepartamentoModel { IdDepartamento = id, NomeDepartamento = novoNome });

    public void CriarDepartamento(string nome)=> _dprepository.CreateDepartamento(new DepartamentoModel { NomeDepartamento = nome });

   public void DeletarDepartamento(int id)
    {
        var departamento = _dprepository.GetDepartamentoById(id);
        if (departamento != null)
        {
            _dprepository.DeleteDepartamentoModel(departamento);
        }
    }

    public DepartamentoModel ObterDepartamentoPorId(int id)=> _dprepository.GetDepartamentoById(id);


    public IEnumerable<DepartamentoModel> ObterTodosDepartamentos()=> _dprepository.GetAllDepartamentos();

}
